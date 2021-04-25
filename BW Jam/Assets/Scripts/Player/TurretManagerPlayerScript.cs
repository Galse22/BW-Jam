using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManagerPlayerScript : MonoBehaviour
{
    public RepairTurretScript repairTurretScript;
    public GameObject currentSpot;
    GameObject curTurretPooled;
    public TurretUIScriptableObject turretUIScriptableObject;
    public GCVarManager gCVarManager;

    public string uiThingyNameToPool;
    public float moneyThatCosts;

    bool hasPlacedAnyTurret;

    public GameObject tutorialTXTGo;

    string sfxBuild = "event:/Player Repair 2";

    [HideInInspector] public bool lostArm;

    private void Update() {
        ChangeScriptableObjects(turretUIScriptableObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "TurretSpot")
        {
            if(col.transform.childCount == 0)
            {
                currentSpot = col.gameObject;
            }
        }
        if(currentSpot != null)
        {
            InputChecker();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "TurretSpot")
        {
            if(col.transform.childCount == 0)
            {
                currentSpot = col.gameObject;
            }
        }
        if(currentSpot != null)
        {
            InputChecker();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "TurretSpot")
        {
            if(currentSpot != null)
            {
                currentSpot = null;            
            }
        }
    }

    void InputChecker()
    {
        if(Input.GetButton("Fire2") && !lostArm)
        {
            if(gCVarManager.CheckMoney(moneyThatCosts))
            {
                CreateTurret();
            }
            if(!hasPlacedAnyTurret)
            {
                Invoke("DisableTutorial", 3.5f);
                hasPlacedAnyTurret = true;
            }
        }
    }

    void CreateTurret()
    {
        GameObject turret1 = ObjectPooler.SharedInstance.GetPooledObject(uiThingyNameToPool);
        turret1.transform.position = currentSpot.transform.position;                
        turret1.transform.SetParent(currentSpot.transform);
        turret1.SetActive(true);
        repairTurretScript.RepairedFunc(turret1);
        currentSpot = null;
        FMODUnity.RuntimeManager.PlayOneShot(sfxBuild, transform.position);
    }

    public void ChangeScriptableObjects(TurretUIScriptableObject newTurretScritableObject)
    {
        turretUIScriptableObject = newTurretScritableObject;
        uiThingyNameToPool = turretUIScriptableObject.uiThingyNameToPool;
        moneyThatCosts = turretUIScriptableObject.moneyThatCosts;
    }

    void DisableTutorial()
    {
        tutorialTXTGo.SetActive(false);
    }

}
