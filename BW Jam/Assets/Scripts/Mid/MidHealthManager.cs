using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidHealthManager : MonoBehaviour
{
    public int health = 4;

    public int dmgType;
    public MidDamageScript midDamageScript;

    Animator anim;

    bool lost;

    Transform healthBar;
    GameObject healthBarGO;

    public bool isOnRange;
    public float healthNeeded = 10f;
    float currentHealth;
    float healthDivided;

    public bool isX;

    private void Start() {
        anim = GetComponent<Animator>();
        healthBar = this.gameObject.transform.GetChild(0);
        healthBarGO = healthBar.gameObject;
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
                health = 4;
                midDamageScript.UntakeDamage(dmgType);
                anim.SetTrigger("back");
                SetAlpha(1f);
            }
        }
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
                healthBarGO.SetActive(true);
                currentHealth = 0.1f;
                healthDivided = currentHealth / healthNeeded;
                ScaleHealthBarFunc();
                SetAlpha(0.8f);
            }
            else
            {
                midDamageScript.MidTakeDamage(0);
            }
        }
    }

    void ScaleHealthBarFunc()
    {
        if(lost == true)
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

    void SetAlpha(float alphaToSet)
    {
        Color tmp = this.gameObject.GetComponent<SpriteRenderer>().color;
        tmp. a = alphaToSet;
        this.gameObject. GetComponent<SpriteRenderer>().color = tmp;
    }
}
