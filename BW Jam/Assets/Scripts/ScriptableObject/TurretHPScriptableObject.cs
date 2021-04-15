using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TurretHPScriptableObject", menuName = "BW Jam/TurretHPScriptableObject", order = 1)]
public class TurretHPScriptableObject : ScriptableObject 
{
    public float baseTurretHealth;
    public float decreaserMultiplier;
}
