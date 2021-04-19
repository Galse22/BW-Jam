using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTurretScript : MonoBehaviour {
    public Transform transformToChangeZ;
    public float timeBeforeShooting;
    public float timeBtwChangeRotation;
    public LayerMask enemyLayerMask;
    public float turretCheckRadius;

    public float angleEnemy;
    public Transform bestEnemy;
    public Vector3 directionAim;
    public Transform thisTransform;

    public Transform[] enemyArray;

    void OnEnable () {
        StartCoroutine ("shootCoroutine");
        StartCoroutine ("calcuateAngleCoroutine");
    }

    IEnumerator shootCoroutine () {
        yield return new WaitForSeconds (timeBeforeShooting);
        GetEnemy ();
        StartCoroutine ("shootCoroutine");
    }

    IEnumerator calcuateAngleCoroutine () {
        yield return new WaitForSeconds (timeBtwChangeRotation);
        GetEnemy ();
        StartCoroutine ("calcuateAngleCoroutine");
    }

    void GetEnemy () {
        bestEnemy = null;
        Collider2D enemyColArray = Physics2D.OverlapCircle (thisTransform.position, turretCheckRadius, enemyLayerMask);
        if(enemyColArray != null)
        {
            bestEnemy = enemyColArray.transform;
            directionAim = (bestEnemy.position - thisTransform.position);
            angleEnemy = Mathf.Atan2 (directionAim.y, directionAim.x) * Mathf.Rad2Deg;
            if (angleEnemy < 0.0f) angleEnemy += 360.0f;
            transformToChangeZ.eulerAngles = new Vector3 (0, 0, angleEnemy);
        }
    }

            // Collider2D[] enemyColArray = Physics2D.OverlapCircleAll (thisTransform.position, turretCheckRadius, enemyLayerMask);
        // enemyArray = new Transform[enemyColArray.Length];
        // for (int i = 0; i < enemyColArray.Length; i++) {
        //     enemyArray[i] = enemyColArray[i].transform;
        // }
        // bestEnemy = GetClosestEnemy (enemyArray);
        //         if (bestEnemy != null) {
        //     directionAim = (bestEnemy.position - thisTransform.position);
        //     angleEnemy = Mathf.Atan2 (directionAim.y, directionAim.x) * Mathf.Rad2Deg;
        //     if (angleEnemy < 0.0f) angleEnemy += 360.0f;
        //     transformToChangeZ.eulerAngles = new Vector3 (0, 0, angleEnemy);
        // }

    // Transform GetClosestEnemy (Transform[] enemies) {
    //     Transform bestTarget = null;
    //     float closestDistanceSqr = Mathf.Infinity;
    //     Vector3 currentPosition = transform.position;
    //     foreach (Transform potentialTarget in enemies) {
    //         Vector3 directionToTarget = potentialTarget.position - currentPosition;
    //         float dSqrToTarget = directionToTarget.sqrMagnitude;
    //         if (dSqrToTarget < closestDistanceSqr) {
    //             closestDistanceSqr = dSqrToTarget;
    //             bestTarget = potentialTarget;
    //         }
    //     }

    //     return bestTarget;
    // }
}