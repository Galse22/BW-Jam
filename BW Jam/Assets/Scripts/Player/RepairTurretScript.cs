using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTurretScript : MonoBehaviour
{
    GameObject currentSpot;

    float activeMoney;

    public GCVarManager gCVarManager;
    public float timeB4RemovingItemFromList;
    public float moneyTurret1;
    public float moneyTurret2;
    public float moneyTurret3;
    public float moneyTurret4;

    public List<GameObject> repairedGOstList;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Turret1")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret1;
        }
        else if(col.gameObject.tag == "Turret2")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret2;
        }
        else if(col.gameObject.tag == "Turret3")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret3;
        }
        else if(col.gameObject.tag == "Turret4")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret4;
        }

        if(currentSpot != null)
        {
            InputChecker();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Turret1")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret1;
        }
        else if(col.gameObject.tag == "Turret2")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret2;
        }
        else if(col.gameObject.tag == "Turret3")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret3;
        }
        else if(col.gameObject.tag == "Turret4")
        {
            currentSpot = col.gameObject;
            activeMoney = moneyTurret4;
        }

        if(currentSpot != null)
        {
            InputChecker();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Turret")
        {
            if(currentSpot != null)
            {
                currentSpot = null;            
            }
        }
    }

    void InputChecker()
    {
        if(Input.GetKey("space"))
        {
            if(!repairedGOstList.Contains(currentSpot) && gCVarManager.CheckMoney(activeMoney))
            {
                RepairTurretFunc();
            }
        }
    }

    void RepairTurretFunc()
    {
        GTurretHealthManager gTurretHealthManager = currentSpot.GetComponent<GTurretHealthManager>();
        gTurretHealthManager.FixTurret();
        repairedGOstList.Add(currentSpot);
        StartCoroutine("RemoveFromListIE", currentSpot);
        currentSpot = null;
    }

    IEnumerator RemoveFromListIE(GameObject goToBeRemoved)
    {
        yield return new WaitForSeconds(timeB4RemovingItemFromList);
        repairedGOstList.Remove(goToBeRemoved);
    }
}
