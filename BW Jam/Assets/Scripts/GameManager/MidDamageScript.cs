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

    string SmallDmgEvent = "event:/Explosion Small";
    string DamageEvent = "event:/Explosion Large";

    [Header("Player Stuff")]

    public GameObject normie;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject noHand;

    bool lostLeft;
    bool lostRight;
    public void MidTakeDamage(int typeOfDamage)
    {
        BothMidAndHeart();
        if(typeOfDamage == 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(SmallDmgEvent, transform.position);
        }
        switch(typeOfDamage)
        {
            // build
            case 1:
                turretManagerPlayerScript.lostArm = true;
                playerAnim.SetBool("lRaB", true);
                lostRight = true;
                if(lostLeft == true)
                {
                    rightHand.SetActive(false);
                    noHand.SetActive(true);
                }
                else
                {
                    normie.SetActive(false);
                    leftHand.SetActive(true);
                }
                SFX1();
                break;

            // up
            case 2:
                playerMovement.lostUpMov = true;
                SFX1();
                break;

            // right
            case 3:
                playerMovement.lostRightMov = true;
                SFX1();
                break;

            // repair
            case 4:
                repairTurretScript.lostArm = true;
                playerAnim.SetBool("lLaB", true);
                lostLeft = true;
                if(lostRight == true)
                {
                    leftHand.SetActive(false);
                    noHand.SetActive(true);
                }
                else
                {
                    normie.SetActive(false);
                    rightHand.SetActive(true);
                }
                SFX1();
                break;
        }
    }

    public void TakeDamageHeart()
    {
        BothMidAndHeart();
        FMODUnity.RuntimeManager.PlayOneShot(SmallDmgEvent, transform.position);
    }

    void BothMidAndHeart()
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
    }

    void SFX1()
    {
        FMODUnity.RuntimeManager.PlayOneShot(DamageEvent, transform.position);
    }
}
