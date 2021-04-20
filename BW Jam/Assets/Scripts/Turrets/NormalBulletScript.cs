using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletScript : MonoBehaviour {
    public float speed;
    public float damage;
    [HideInInspector] public Transform targetPos;

    private void OnDisable () {
        targetPos = null;
    }
    void Update () {
        if (targetPos != null) {
            transform.position = Vector2.MoveTowards (transform.position, targetPos.position, speed * Time.deltaTime);
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