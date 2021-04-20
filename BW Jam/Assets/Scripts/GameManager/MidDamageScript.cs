using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidDamageScript : MonoBehaviour
{

    public MusicManager musicManager;
    public RepairTurretScript repairTurretScript;
    public TurretManagerPlayerScript turretManagerPlayerScript;

    public PlayerMovement playerMovement;

    public Animator playerAnim;
    public float sIntensity;
    public float sTime;
    GameObject[] bullets;
    GameObject[] enemies;
    public void MidTakeDamage(int typeOfDamage)
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject bullet in bullets)
        {
            bullet.SetActive(false);
        }
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }

        CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        musicManager.IncreaseDanger();
        switch(typeOfDamage)
        {
            // build
            case 1:
                turretManagerPlayerScript.lostArm = true;
                playerAnim.SetTrigger("lostRightArm");
                break;

            // up
            case 2:
                playerMovement.lostUpMov = true;
                break;

            // right
            case 3:
                playerMovement.lostRightMov = true;
                break;

            // repair
            case 4:
                repairTurretScript.lostArm = true;
                playerAnim.SetTrigger("lostLefttArm");
                break;
        }
    }
}
