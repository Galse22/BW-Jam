using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultipleEnemiesTurretScript : MonoBehaviour
{
    public float timeBtwAttack;
    public float dmgToDeal;
    public float attackRadius;
    public Transform thisTransform;
    public LayerMask enemyLayerMask;

    GameObject[] enemyArray;
    public string sfxString;
    int enableInt;

    private void OnEnable() {
        if(enableInt > 0)
        {
            StartCoroutine ("checkForEnemies");
        }
        enableInt++;
    }

    IEnumerator checkForEnemies()
    {
        yield return new WaitForSeconds (timeBtwAttack);
        Collider2D[] enemyColArray = Physics2D.OverlapCircleAll (thisTransform.position, attackRadius, enemyLayerMask);
        if(enemyColArray.Length != 0)
        {
            enemyArray = new GameObject[enemyColArray.Length];
            for (int i = 0; i < enemyColArray.Length; i++) {
                enemyArray[i] = enemyColArray[i].gameObject;
            }
            foreach(GameObject enemy in enemyArray)
            {
                EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
                enemyScript.TakeDamage(dmgToDeal);
            }
            FMODUnity.RuntimeManager.PlayOneShot(sfxString, transform.position);
        }
        StartCoroutine ("checkForEnemies");
    }
}
