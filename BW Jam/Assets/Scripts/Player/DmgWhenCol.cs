using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgWhenCol : MonoBehaviour
{
    public HeartHealthScript heartHealthScript;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.SetActive(false);
            heartHealthScript.DamageHeart();
        }
    }
}
