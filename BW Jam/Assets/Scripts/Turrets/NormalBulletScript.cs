using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletScript : MonoBehaviour {
    public float speed;
    public float damage;
    [HideInInspector] public Transform targetPos;

    int enableInt;

    float maxTimeOnField = 8.2f;
    float timeOnField;

    private void OnDisable () {
        targetPos = null;
        timeOnField = 0;
    }

    private void OnEnable() {
        if(enableInt != 0)
        {
            Invoke("StartTimeIV", 0.3f);
        }
        else
        {
            enableInt++;
        }
    }

    void Update () {
        if (targetPos != null) {
            transform.position = Vector2.MoveTowards (transform.position, targetPos.position, speed * Time.deltaTime);
        }
    }

    void StartTimeIV()
    {
        if(this.gameObject.activeInHierarchy)
        {
            StartCoroutine("checkTime");
        }
    }

    IEnumerator checkTime()
    {
        yield return new WaitForSeconds(0.2f);
        timeOnField += 0.21f;
        if(timeOnField >= maxTimeOnField)
        {
            this.gameObject.SetActive(false);
        }
        if(this.gameObject.activeInHierarchy)
        {
            StartCoroutine("checkTime");
        }
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            EnemyScript enemyScript = col.GetComponent<EnemyScript> ();
            enemyScript.TakeDamage (damage);
            this.gameObject.SetActive (false);
        }
    }
}