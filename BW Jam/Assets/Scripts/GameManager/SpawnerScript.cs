using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    // very informative header name xd
    [Header("Normal Variables")]
    public float timeBtwSpawn;
    public float minimumTime;
    public float timeToDecrease;

    public GCVarManager gCVarManager;

    public int enemyKillsToChangeTime;

    public List<float> tDecreaserFloat;
    public List<float> tDecreaserFloatList;

    [Header("Boss Stuff")]
    public float timeBtwOneBossPerWaveIsDisabled;
    public int oddInt;
    public float minToStartBoss;

    public List<float> oddChangerFloat;
    public List<int> oddChangerInt;

    [Header("Places N Stuff")]
    public Transform[] placesToSpawnEnemy;
    public Transform[] pathEnemyLeft;
    public Transform[] pathEnemyTop;
    public Transform[] pathEnemyRight;
    public Transform[] pathEnemyBottom;

    int indexNumber;

    int forIndexNumber;
    int oddIntInCode;
    
    int enemyKills;
    bool oddBool;

    int lastFloat;
    float floatToCopare;
    int lastInt;
    int intToCompare;

    bool listChanged = true;

    bool tDListChanged = true;

    int tDLastFloat;
    float tDFloatToCopare; 
    // yes I know it's COMPARE not copare. I made a typo and dont feel like replacing my variables
    int tDLastInt;
    float tDOFToCompare;

    GameObject enemySpawned;
    EnemyScript enemyScript;
    bool shouldStartBoss;
    bool oneBossPerWave = true;
    bool tDbool;
    bool oddElseBool;
    void Start()
    {
        StartCoroutine("SpawnerCoroutine");
        forIndexNumber = oddChangerFloat.Count;
    }

    IEnumerator SpawnerCoroutine()
    {
        yield return new WaitForSeconds(timeBtwSpawn);
        foreach(Transform place in placesToSpawnEnemy)
        {
            
            oddIntInCode = Random.Range(0, oddInt + 1);
            if(!oneBossPerWave)
            {
                if(oddIntInCode == 1 && shouldStartBoss)
                {
                    oddBool = true;
                    enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("BigEnemy");
                }
                else
                {
                    enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
                }
            }
            else
            {
                if(oddBool == false && oddIntInCode == 1 && shouldStartBoss)
                {
                    oddBool = true;
                    enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("BigEnemy");
                }
                else
                {
                    enemySpawned = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
                }
            }
            enemyScript = enemySpawned.GetComponent<EnemyScript>();
            switch(indexNumber)
            {
                case 0:
                    enemyScript.waypoints = pathEnemyLeft;
                    break;
                case 1:
                    enemyScript.waypoints = pathEnemyTop;
                    break;
                case 2:
                    enemyScript.waypoints = pathEnemyRight;
                    break;
                case 3:
                    enemyScript.waypoints = pathEnemyBottom;
                    break;
                default:
                    Debug.LogError("Frick");
                    break;
            }
            enemySpawned.transform.position = place.transform.position;                
            enemySpawned.transform.SetParent(place.transform);
            enemySpawned.SetActive(true);
            indexNumber++;
        }
        indexNumber = 0;
        oddBool = false;
        StartCoroutine("SpawnerCoroutine");
    }

    void DecreaseTimeBtwSpawnFunc()
    {
        if(timeBtwSpawn - timeToDecrease >= minimumTime)
        {
            timeBtwSpawn -= timeToDecrease;
            FloatNBoolsShenanigans();
        }
        else
        {
            timeBtwSpawn = minimumTime;
            if(oddElseBool == false || tDbool == false)
            {
                TimeDecreaserStuff();
                BossOddStuff();
            }
        }
    }

    public void EnemyKilled(float moneyToIncrease, int scorePlus)
    {
        enemyKills++;
        gCVarManager.ChangeMoney(moneyToIncrease);
        gCVarManager.ScoreFunc(scorePlus);
        if(enemyKillsToChangeTime <= enemyKills)
        {
            enemyKills = 0;
            DecreaseTimeBtwSpawnFunc();
        }
    }

    void FloatNBoolsShenanigans()
    {
        if(timeBtwSpawn <= minToStartBoss)
        {
            shouldStartBoss = true;
        }
        if(timeBtwSpawn <= timeBtwOneBossPerWaveIsDisabled)
        {
            oneBossPerWave = false;
        }
        TimeDecreaserStuff();
        BossOddStuff();
    }

    void TimeDecreaserStuff()
    {
        if(tDListChanged)
        {
            tDLastFloat = tDecreaserFloat.Count;
            tDLastFloat--;
            tDListChanged = false;
        }
        if(tDLastFloat > -1)
        {
            tDFloatToCopare = tDecreaserFloat[tDLastFloat];
            if(tDFloatToCopare >= timeBtwSpawn)
            {
                tDLastInt = tDecreaserFloatList.Count;
                tDLastInt--;
                tDOFToCompare = tDecreaserFloatList[tDLastInt];
                timeToDecrease = tDOFToCompare;
                tDecreaserFloat.Remove(tDFloatToCopare);
                tDecreaserFloatList.Remove(tDOFToCompare);
                tDListChanged = true;
            }
        }
        else
        {
            tDbool = true;
        }
    }

    void BossOddStuff()
    {
        if(listChanged)
        {
            lastFloat = oddChangerFloat.Count;
            lastFloat--;
            listChanged = false;
        }
        if(lastFloat > -1)
        {
            floatToCopare = oddChangerFloat[lastFloat];
            if(floatToCopare >= timeBtwSpawn)
            {
                lastInt = oddChangerInt.Count;
                lastInt--;
                intToCompare = oddChangerInt[lastInt];
                oddInt = intToCompare;
                oddChangerFloat.Remove(floatToCopare);
                oddChangerInt.Remove(intToCompare);
                listChanged = true;
            }
        }
        else
        {
            oddElseBool= true;
        }
    }
}
