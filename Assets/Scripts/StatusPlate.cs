using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "ScriptableObjects/Status Plates", order = 1)]
public class StatusPlate : ScriptableObject
{
    public float health;
    public float pdamage;
    public float mdamage;
    public float armour;
    public float marmour;
    public float speed;
    public float aspd;
    public float crit;

    public bool magtype;
}
