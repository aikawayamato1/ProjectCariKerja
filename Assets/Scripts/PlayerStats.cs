using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Attributes")]
    public float intel;
    public float str;
    public float agi;
    public float con;

    [Header("Damage")]
    public float attack;
    public float mattack;

    [Header("Mana")]
    public float manaregen;
    public float mana;

    [Header("Defense")]
    public float health;
    public float defense;
    public float mdefense;
    public float hpregen;

    [Header("Critical")]
    public float cr;
    public float cdm;
    public float crits;

    [Header("Attack Speed")]
    public float aspd;
    public float totalaspd;

    [Header("Plates")]
    public StatusPlate sp;

    private void Start()
    {
        attack = sp.pdamage;
        defense = sp.armour;
        mdefense = sp.marmour;
        aspd = sp.aspd;
        crits = sp.crit;
        if (crits > 10000f)
        {
            crits = 10000f;
        }
        Strenght();
        Intelligence();
        Agility();
        Constitution();
        CriticalCounter();


    }
    private void Update()
    {
        
    }
    private void CriticalCounter()
    {
      
        cr = crits / 100f;
        cdm = crits / 10f;
    }

    public void Strenght()
    {
        attack = attack + str*10f;
        defense = defense + str * 5f;
    }
    public void Intelligence()
    {
        mattack = mattack + intel * 10f;
        mana = intel * 100f;
        manaregen = intel * 0.1f;

    }
    public void Agility()
    {
        crits = crits + agi * 0.5f;
        aspd = aspd + agi * 0.01f;
        if(aspd>=100f)
        {
            aspd = 99.9f;
            totalaspd = 100f - aspd;
            totalaspd = totalaspd / 100;
            totalaspd = totalaspd * 3;
        }
        else
        {
            totalaspd = 100f - aspd;
            totalaspd = totalaspd / 100;
            totalaspd = totalaspd * 3;
        }
        
    }
    public void Constitution()
    {
        health = con * 100f;
        mdefense = mdefense + con * 0.5f;
    }
}
