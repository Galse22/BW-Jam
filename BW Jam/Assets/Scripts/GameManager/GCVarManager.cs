﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCVarManager : MonoBehaviour {

    [Header("Score")]
    public int score;
    public Text scoreTXT;

    [Header ("Money")]
    public float money;
    public Text moneyTXT;

    [Header("Screenshake Stuff")]
    public float sIntesityNoMoney;
    public float sTimeNoMoney;
    void Update () {
        moneyTXT.text = money.ToString ();
    }

    public bool CheckMoney(float moneyToDecrease)
    {
        if(money - moneyToDecrease >= 0)
        {
            money -= moneyToDecrease;
            moneyTXT.text = money.ToString ();
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
        moneyTXT.text = money.ToString ();
    }
}