using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public float money;
    public Text moneyTXT;
    void Update()
    {
        moneyTXT.text = money.ToString();
    }

    public void ChangeMoney(float moneyToChange)
    {
        money = money + moneyToChange;
        moneyTXT.text = money.ToString();
    }
}
