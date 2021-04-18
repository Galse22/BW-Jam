using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTurretScript : MonoBehaviour {
    public Transform transformToChangeZ;
    float angleEnemy;
    Transform bestEnemy;
    Vector2 directionAim;
    Transform thisTransform;

    void Start () {
        thisTransform = GetComponent<Transform> ();
        StartCoroutine ("shootCoroutine");
        StartCoroutine ("calcuateAngleCoroutine");
    }

    IEnumerator shootCoroutine () {
        yield return new WaitForSeconds (timeBtwSpawn);
        StartCoroutine ("shootCoroutine");
    }

    IEnumerator calcuateAngleCoroutine () {
        yield return new WaitForSeconds (timeBtwSpawn);
        GetEnemy ();
        StartCoroutine ("calcuateAngleCoroutine");
    }

    void GetEnemy () {
        bestEnemy = GetClosestEnemy ();
        directionAim = (bestEnemy.position - thisTransform.position).normalized;
        angleEnemy = Mathf.Atan2 (directionAim.y, directionAim.x) * Mathf.Rad2Deg - 90f;
        if (angleEnemy < 0.0f) angleEnemy += 360.0f;
        //transformToChangeZ
    }

    Transform GetClosestEnemy (Transform[] enemies) {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies) {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}