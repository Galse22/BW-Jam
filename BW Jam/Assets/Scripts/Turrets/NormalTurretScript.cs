using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTurretScript : MonoBehaviour {
    public Transform transformToChangeZ;
    public float timeBeforeShooting;
    public float timeBtwChangeRotation;
    public LayerMask enemyLayerMask;

    public LayerMask bigEnemyLayerMask;
    public float turretCheckRadius;

    float angleEnemy;
    Transform bestEnemy;
    Vector3 directionAim;
    public Transform thisTransform;
    public Transform transformToBeAimedAt;
    public Transform firePlace;

    public string bulletString;

    public string sfxString;
    private void OnDisable() {
        transformToChangeZ.eulerAngles = new Vector3 (0, 0, 0);
    }
    void OnEnable () {
        StartCoroutine ("shootCoroutine");
        StartCoroutine ("calcuateAngleCoroutine");
    }

    IEnumerator shootCoroutine () {
        yield return new WaitForSeconds (timeBeforeShooting);
        GetEnemy (true);
        if(transformToBeAimedAt != null)
        {
            GameObject spawnedBullet = ObjectPooler.SharedInstance.GetPooledObject(bulletString);
            spawnedBullet.transform.position =  firePlace.transform.position;
            spawnedBullet.transform.rotation =  transformToChangeZ.rotation;
            NormalBulletScript normalBulletScript = spawnedBullet.GetComponent<NormalBulletScript>();
            normalBulletScript.targetPos = transformToBeAimedAt;
            spawnedBullet.SetActive(true);
            FMODUnity.RuntimeManager.PlayOneShot(sfxString, transform.position);
        }
        transformToBeAimedAt = null;
        StartCoroutine ("shootCoroutine");
    }

    IEnumerator calcuateAngleCoroutine () {
        yield return new WaitForSeconds (timeBtwChangeRotation);
        GetEnemy (false);
        StartCoroutine ("calcuateAngleCoroutine");
    }

    void GetEnemy (bool shouldSetGo) {
        bestEnemy = null;
        Collider2D enemyColArray = Physics2D.OverlapCircle (thisTransform.position, turretCheckRadius, bigEnemyLayerMask);
        if(enemyColArray != null)
        {
            bestEnemy = enemyColArray.transform;
            directionAim = (bestEnemy.position - thisTransform.position);
            angleEnemy = Mathf.Atan2 (directionAim.y, directionAim.x) * Mathf.Rad2Deg;
            if (angleEnemy < 0.0f) angleEnemy += 360.0f;
            transformToChangeZ.eulerAngles = new Vector3 (0, 0, angleEnemy);
            if(shouldSetGo)
            {
                transformToBeAimedAt = bestEnemy;
            }
        }
        else
        {
            Collider2D enemyColArray2 = Physics2D.OverlapCircle (thisTransform.position, turretCheckRadius, enemyLayerMask);
            if(enemyColArray2 != null)
            {
                bestEnemy = enemyColArray2.transform;
                directionAim = (bestEnemy.position - thisTransform.position);
                angleEnemy = Mathf.Atan2 (directionAim.y, directionAim.x) * Mathf.Rad2Deg;
                if (angleEnemy < 0.0f) angleEnemy += 360.0f;
                transformToChangeZ.eulerAngles = new Vector3 (0, 0, angleEnemy);
                if(shouldSetGo)
                {
                    transformToBeAimedAt = bestEnemy;
                }
            }
        }
    }
}