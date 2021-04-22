using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidRangeColChecker : MonoBehaviour
{
    GameObject parentt;
    MidHealthManager midHealthManager;
    BoxCollider2D bc2d;

    float colX = 3.1f;
    float colY = 3.1f;
    void Awake()
    {
        Transform transformParentt = this.gameObject.transform.parent;
        parentt = transformParentt.gameObject;
        midHealthManager = parentt.GetComponent<MidHealthManager>();
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.size = new Vector2(colX, colY);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "PlayerCol")
        {
            midHealthManager.isOnRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "PlayerCol")
        {
            midHealthManager.isOnRange = false;
        }
    }
}
