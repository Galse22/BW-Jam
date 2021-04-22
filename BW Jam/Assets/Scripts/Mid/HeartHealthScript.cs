using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthScript : MonoBehaviour
{
    public int health = 4;
    public MidDamageScript midDamageScript;

    Animator anim;

    public GameObject goLost;
    public GameObject rightSideGO;

    private void Start() {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.SetActive(false);
            ThatFunc();
        }
    }

    public void DamageHeart()
    {
        ThatFunc();       
    }

    void ThatFunc()
    {
        health--;
        anim.SetTrigger("lostHealth");
        if(health == 0 || health == -1 || health == -2)
        {
            rightSideGO.SetActive(false);
            goLost.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            midDamageScript.TakeDamageHeart();
        }
    }
}
