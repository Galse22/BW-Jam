using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManagerPlayerScript : MonoBehaviour
{
    public GameObject currentSpot;


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
            if(Input.GetButton("Fire1"))
            {
                GameObject turret1 = ObjectPooler.SharedInstance.GetPooledObject("Turret1");
                turret1.transform.SetParent(currentSpot.transform);
                currentSpot = null;
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
            if(Input.GetButton("Fire1"))
            {
                GameObject turret = ObjectPooler.SharedInstance.GetPooledObject("Turret1");
                if (turret != null) {
                    turret.transform.position = currentSpot.transform.position;
                    turret.transform.rotation = currentSpot.transform.rotation;
                    turret.SetActive(true);
                    turret.transform.SetParent(currentSpot.transform);
                    currentSpot = null;
                }
            }
        }
    }
}
