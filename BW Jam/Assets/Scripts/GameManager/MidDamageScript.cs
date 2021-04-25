using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidDamageScript : MonoBehaviour {

    MusicManager musicManager;
    public RepairTurretScript repairTurretScript;
    public TurretManagerPlayerScript turretManagerPlayerScript;

    public PlayerMovement playerMovement;
    public GCVarManager gCVarManager;

    public Animator playerAnim;
    public float sIntensity;
    public float sTime;
    GameObject[] bullets;
    GameObject[] enemies;

    public float moneyToIncreaseOnLostHealth;

    string SmallDmgEvent = "event:/Explosion Small";
    string DamageEvent = "event:/Explosion Large";

    [Header ("Player Stuff")]

    public GameObject normie;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject noHand;

    bool lostLeft;
    bool lostRight;

    private void Start() {
         musicManager = GameObject.FindWithTag("MusicManagerGO").GetComponent<MusicManager>();
    }
    public void MidTakeDamage (int typeOfDamage) {
        BothMidAndHeart ();
        if (typeOfDamage == 0) {
            FMODUnity.RuntimeManager.PlayOneShot (SmallDmgEvent, transform.position);
        }
        switch (typeOfDamage) {
            // build
            case 1:
                turretManagerPlayerScript.lostArm = true;
                playerAnim.SetBool ("lRaB", true);
                lostRight = true;
                if (lostLeft == true) {
                    rightHand.SetActive (false);
                    noHand.SetActive (true);
                } else {
                    normie.SetActive (false);
                    leftHand.SetActive (true);
                }
                SFX1 ();
                break;

                // up
            case 2:
                playerMovement.lostUpMov = true;
                SFX1 ();
                break;

                // right
            case 3:
                playerMovement.lostRightMov = true;
                SFX1 ();
                break;

                // repair
            case 4:
                repairTurretScript.lostArm = true;
                playerAnim.SetBool ("lLaB", true);
                lostLeft = true;
                if (lostRight == true) {
                    leftHand.SetActive (false);
                    noHand.SetActive (true);
                } else {
                    normie.SetActive (false);
                    rightHand.SetActive (true);
                }
                SFX1 ();
                break;
        }
    }

    public void TakeDamageHeart () {
        BothMidAndHeart ();
        musicManager.P3D ();
        FMODUnity.RuntimeManager.PlayOneShot (SmallDmgEvent, transform.position);
    }

    public void CallMusicFunc()
    {
        musicManager.IncreaseDanger ();
    }

    void BothMidAndHeart () {
        bullets = GameObject.FindGameObjectsWithTag ("Bullet");
        enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        foreach (GameObject bullet in bullets) {
            bullet.SetActive (false);
        }
        foreach (GameObject enemy in enemies) {
            enemy.SetActive (false);
        }
        CinemachineShake.Instance.ShakeCamera (sIntensity, sTime);
        gCVarManager.ChangeMoney(moneyToIncreaseOnLostHealth);
    }

    void SFX1 () {
        FMODUnity.RuntimeManager.PlayOneShot (DamageEvent, transform.position);
    }

    public void UntakeDamage (int damageType) {
        musicManager.ReduceDanger(2);
        switch (damageType) {
            // build
            case 1:
                turretManagerPlayerScript.lostArm = false;
                playerAnim.SetBool ("lRaB", false);
                lostRight = false;
                if (lostLeft == true) {
                    playerAnim.SetTrigger("backToR");
                    rightHand.SetActive (true);
                    noHand.SetActive (false);
                } else {
                    playerAnim.SetTrigger("backToS");
                    normie.SetActive (true);
                    leftHand.SetActive(false);
                }
                break;

                // up
            case 2:
                playerMovement.lostUpMov = false;
                SFX1 ();
                break;

                // right
            case 3:
                playerMovement.lostRightMov = false;
                break;

                // repair
            case 4:
                repairTurretScript.lostArm = false;
                playerAnim.SetBool ("lLaB", false);
                lostLeft = false;
                if (lostRight == true) {
                    playerAnim.SetTrigger("backToL");
                    leftHand.SetActive (true);
                    noHand.SetActive (false);
                } else {
                    normie.SetActive (true);
                    playerAnim.SetTrigger("backToS");
                    rightHand.SetActive (false);
                }
                break;
        }
    }
}