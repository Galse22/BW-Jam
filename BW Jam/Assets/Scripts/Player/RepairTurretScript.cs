﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTurretScript : MonoBehaviour
{
    GameObject currentSpot;

    float activeMoney;

    public GCVarManager gCVarManager;
    public PlayerMovement playerShmovement;

    public float timeMoveSpeedBoost;
    public float otherMoveSpeed;
    public float timeB4RemovingItemFromList;
    public float moneyTurret1;
    public float moneyTurret2;
    public float moneyTurret3;
    public float moneyTurret4;

    float baseMoveSpeedPlayer;
    

    [HideInInspector] public bool lostArm;

    public List<GameObject> repairedGOstList;

    private void Start() {
        baseMoveSpeedPlayer = playerShmovement.moveSpeed;
    }
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
        if(Input.GetKey("space") && !lostArm)
        {
            if(!repairedGOstList.Contains(currentSpot) && gCVarManager.CheckMoney(activeMoney))
            {
                RepairTurretFunc();
                playerShmovement.moveSpeed = otherMoveSpeed;
                CancelInvoke("SpeedBoost");
                Invoke("SpeedBoost", timeMoveSpeedBoost);
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

    void SpeedBoost()
    {
        playerShmovement.moveSpeed = baseMoveSpeedPlayer;
    }
}
