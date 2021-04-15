using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTurretHealthManager : MonoBehaviour
{
    [SerializeField] public TurretHPScriptableObject healthScriptableObject;

    public float baseTurretHealth = 1000;
    public float currentHealth = 1000;
    public float decreaserMultiplier;

    bool gracePeriod;

    void Start()
    {
        defineVariablesScriptableObject();
    }

    private void OnEnable() {
        gracePeriod = true;
        Invoke("ungracePeriod", 0.2f);
        defineVariablesScriptableObject();
    }

    private void OnDisable() {
        defineVariablesScriptableObject();
    }

    private void Update() {
        if(!gracePeriod)
        {
            currentHealth = currentHealth - 1 * decreaserMultiplier * Time.deltaTime;
            if(currentHealth <= 0)
            {
                this.gameObject.transform.parent = null;
                this.gameObject.SetActive(false);
            }
        }
    }

    public void FixTurret()
    {
        currentHealth = baseTurretHealth;
        // update mini UI
    }

    void ungracePeriod()
    {
        gracePeriod = false;
    }
    void redefineVariables()
    {
        currentHealth = baseTurretHealth;
    }
    void defineVariablesScriptableObject()
    {
        baseTurretHealth = healthScriptableObject.baseTurretHealth;
        decreaserMultiplier =  healthScriptableObject.decreaserMultiplier;
        currentHealth = baseTurretHealth;
    }
}
