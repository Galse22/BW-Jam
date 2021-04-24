using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCVarManager : MonoBehaviour {

    [Header("Score")]
    public int score;
    public Text scoreTXT;

    public GameObject mt;
    
    public int scoreToEnableMT;
    public GameObject st;
    public int scoreToEnableST;

    bool stEnabled;
    bool mtEnabled;

    public float sIntensityT;
    public float sTimeT;

    string unlockTurretSFX = "event:/Item Pickup";

    [Header ("Money")]
    public float money;
    public Text moneyTXT;

    [Header("Screenshake Stuff")]
    public float sIntesityNoMoney;
    public float sTimeNoMoney;

    private void Start() {
        moneyTXT.text = "Money: " + money.ToString ();
    }

    public bool CheckMoney(float moneyToDecrease)
    {
        if(money - moneyToDecrease >= 0)
        {
            money -= moneyToDecrease;
            moneyTXT.text = "Money: " + money.ToString ();
            return true;
        }
        else
        {
            // must create SFX
            CinemachineShake.Instance.ShakeCamera (sIntesityNoMoney, sTimeNoMoney);
            return false;
        }
    }

    public void ChangeMoney (float moneyToChange) {
        money = money + moneyToChange;
        moneyTXT.text = "Money: " + money.ToString ();
    }

    public void ScoreFunc(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTXT.text = "Score: " + score.ToString ();
        if(PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        if(!stEnabled)
        {
            if(scoreToEnableST <= score)
            {
                st.SetActive(true);
                stEnabled = true;
                SShakeAndSFX();
            }
        }
        if(!mtEnabled)
        {
            if(scoreToEnableMT <= score)
            {
                mt.SetActive(true);
                mtEnabled = true;
                SShakeAndSFX();
            }
        }
    }

    void SShakeAndSFX()
    {
        CinemachineShake.Instance.ShakeCamera (sIntensityT, sTimeT);
        FMODUnity.RuntimeManager.PlayOneShot(unlockTurretSFX);
    }
}