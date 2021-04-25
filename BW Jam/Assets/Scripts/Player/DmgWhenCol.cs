using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgWhenCol : MonoBehaviour
{
    public HeartHealthScript heartHealthScript;
    bool canTakeDamage = true;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy" && canTakeDamage) {
            canTakeDamage = false;
            col.gameObject.SetActive(false);
            heartHealthScript.DamageHeart();
            Invoke("canTakeDamageFunc", 0.9f);
        }
    }

    void canTakeDamageFunc()
    {
        canTakeDamage = true;
    }
}
