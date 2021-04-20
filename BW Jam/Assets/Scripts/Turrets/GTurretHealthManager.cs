using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTurretHealthManager : MonoBehaviour {
    [SerializeField] public TurretHPScriptableObject healthScriptableObject;

    float baseTurretHealth = 1000;
    float currentHealth = 1000;
    float decreaserMultiplier;
    float healthDivided;

    bool gracePeriod;

    public Transform healthBar;

    void Start () {
        defineVariablesScriptableObject ();
    }

    private void OnEnable () {
        gracePeriod = true;
        Invoke ("ungracePeriod", 0.2f);
        redefineVariables ();
    }

    private void OnDisable () {
        redefineVariables ();
        ChangeHealthBar ();
    }

    private void Update () {
        if (!gracePeriod) {
            currentHealth = currentHealth - 1 * decreaserMultiplier * Time.deltaTime;
            ChangeHealthBar ();
            if (currentHealth <= 0) {
                this.gameObject.transform.parent = null;
                this.gameObject.SetActive (false);
            }
        }
    }

    public void FixTurret () {
        currentHealth = baseTurretHealth;
        ChangeHealthBar ();
    }

    void ChangeHealthBar () {
        healthDivided = currentHealth / baseTurretHealth;
        healthBar.localScale = new Vector3 (healthDivided, 1);
    }

    void ungracePeriod () {
        gracePeriod = false;
    }
    void redefineVariables () {
        currentHealth = baseTurretHealth;
    }
    void defineVariablesScriptableObject () {
        baseTurretHealth = healthScriptableObject.baseTurretHealth;
        decreaserMultiplier = healthScriptableObject.decreaserMultiplier;
        currentHealth = baseTurretHealth;
    }
}