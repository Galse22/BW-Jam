using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletScript : MonoBehaviour {
    public float speed;
    public float damage;
    [HideInInspector] public Transform targetPos;

    int enableInt;

    private void OnDisable () {
        targetPos = null;
    }

    private void OnEnable() {
        if(enableInt != 0)
        {
            Invoke("StartCC", 0.3f);
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

    void StartCC()
    {
        if(this.gameObject.activeInHierarchy)
        {
            StartCoroutine("checkEnemyCoroutine");
        }
    }

    IEnumerator checkEnemyCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        if(targetPos == null)
        {
            this.gameObject.SetActive(false);
        }
        StartCoroutine("checkEnemyCoroutine");
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            EnemyScript enemyScript = col.GetComponent<EnemyScript> ();
            enemyScript.TakeDamage (damage);
            this.gameObject.SetActive (false);
        }
    }
}