using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManagerPlayerScript : MonoBehaviour
{
    public GameObject currentSpot;
    GameObject curTurretPooled;


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
            if(Input.GetButton("Fire2"))
            {
                CreateTurret();
            }
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
            if(Input.GetButton("Fire2"))
            {
                CreateTurret();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(currentSpot != null)
        {
            currentSpot = null;            
        }
    }

    void CreateTurret()
    {
        GameObject turret1 = ObjectPooler.SharedInstance.GetPooledObject("Turret1");
        turret1.transform.position = currentSpot.transform.position;                
        turret1.transform.SetParent(currentSpot.transform);
        turret1.SetActive(true);
        currentSpot = null;
    }

}
