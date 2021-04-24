using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public TurretManagerPlayerScript turretManagerPlayerScript;

    [Header("Scriptable Objects")]
    public TurretUIScriptableObject turretUIScriptableObject1;
    public TurretUIScriptableObject turretUIScriptableObject2;
    public TurretUIScriptableObject turretUIScriptableObject3;

    public GameObject[] borderArray;

    string sfxString = "event:/Turret Select";

    void GeneralFunc(TurretUIScriptableObject newTurretScritableObject, int objToActivate)
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxString, transform.position);
        turretManagerPlayerScript.ChangeScriptableObjects(newTurretScritableObject);
        foreach(GameObject border in borderArray)
        {
            border.SetActive(false);
        }
        borderArray[objToActivate].SetActive(true);
    }
    public void Button1Func()
    {
        GeneralFunc(turretUIScriptableObject1, 0);
    }

    public void Button2Func()
    {
        GeneralFunc(turretUIScriptableObject2, 1);
    }

    public void Button3Func()
    {
        GeneralFunc(turretUIScriptableObject3, 2);
    }
}
