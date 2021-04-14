using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretUIScriptableObject", menuName = "BW Jam/TurretUIScriptableObject", order = 0)]
public class TurretUIScriptableObject : ScriptableObject 
{
    public GameObject turretToPool;
    public string uiThingyNameToPool;

    public float moneyThatCosts;
}
