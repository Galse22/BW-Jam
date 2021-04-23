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
    int enemyKills;
    public float timeBtwOneBossPerWaveIsDisabled;

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

    public int oddInt;
    public float minToStartBoss;
    int oddIntInCode;
    bool oddBool;

    float lastFloat;
    int lastInt;

    bool listChanged = true;

    GameObject enemySpawned;
    EnemyScript enemyScript;
    bool shouldStartBoss;
    bool oneBossPerWave = true;
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
        if(listChanged)
        {
            lastFloat = oddChangerFloat.Count;
            lastFloat--;
        }
        if(lastFloat >= timeBtwSpawn)
        {
            lastInt = oddChangerInt.Count;
            lastInt--;
            oddInt = lastInt;
            oddChangerFloat.Remove(lastFloat);
            oddChangerInt.Remove(lastInt);
            listChanged = true;
        }
    }
}
