using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidHealthManager : MonoBehaviour
{
    public int health = 4;

    public int dmgType;
    public MidDamageScript midDamageScript;

    public GameObject goToEnableOnDisable;

    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnDisable() {
        goToEnableOnDisable.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.SetActive(false);
            health--;
            anim.SetTrigger("lostHealth");
            if(health == 0 || health == -1 || health == -2)
            {
                midDamageScript.MidTakeDamage(dmgType);
                this.gameObject.SetActive(false);
            }
            else
            {
                midDamageScript.MidTakeDamage(0);
            }
        }
    }
}
