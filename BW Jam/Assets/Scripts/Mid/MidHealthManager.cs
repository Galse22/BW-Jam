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

    bool lost;

    public Transform healthBar;
    public GameObject healthBarGO;

    public bool isOnRange;
    float healthNeeded;
    float currentHealth;
    float healthDivided;

    public bool isX;

    public bool isXHealth;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isOnRange && lost)
        {
            currentHealth += Time.deltaTime;
            healthDivided = currentHealth / healthNeeded;
            ScaleHealthBarFunc();

            if(currentHealth >= healthNeeded)
            {
                lost = false;
                healthBarGO.SetActive(false);
            }
        }
    }

    private void OnDisable() {
        goToEnableOnDisable.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy" && !lost) {
            col.gameObject.SetActive(false);
            health--;
            anim.SetTrigger("lostHealth");
            if(health == 0 || health == -1 || health == -2)
            {
                midDamageScript.MidTakeDamage(dmgType);
                lost = true;
                healthBarGO.SetActive(false);
                currentHealth = 0f;
                ScaleHealthBarFunc();
            }
            else
            {
                midDamageScript.MidTakeDamage(0);
            }
        }
    }

    void ScaleHealthBarFunc()
    {
        if(isX)
        {
            healthBar.localScale = new Vector3 (healthDivided, 1);
        }
        else
        {
            healthBar.localScale = new Vector3 (1, healthDivided);
        }
    }
}
