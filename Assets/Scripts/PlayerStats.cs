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
    public float atktotal;
    public float attackmin;
    public float mattackmin;

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

    [Header("Magic Type")]
    public bool magicType;

    private void Start()
    {
        attack = sp.pdamage;
        mattack = sp.mdamage;
        attackmin = sp.pdamage;
        mattackmin = sp.mdamage;
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
        attackmin = attackmin + str * 5f;
        defense = defense + str * 5f;
    }
    public void Intelligence()
    {
        mattack = mattack + intel * 10f;
        mattackmin = mattackmin + intel * 5f;
        mana = intel * 2f;
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
            totalaspd = totalaspd * 2;
        }
        else
        {
            totalaspd = 100f - aspd;
            totalaspd = totalaspd / 100;
            totalaspd = totalaspd * 2;
        }
        
    }
    public void Constitution()
    {
        health = con * 2f;
        mdefense = mdefense + con * 0.5f;
        hpregen = con * 0.1f;
    }
    public float GetAttackSpeed()
    {
        return totalaspd;
    }
    public float AttackCounter()
    {
        int randomN=Random.Range(1,100);
        float randomMinP = Random.Range(attackmin, attack);
        float randomMinM = Random.Range(mattackmin, mattack);
        if (randomN<=cr)
        {
            Debug.Log("Crit!!");
            if (!magicType)
            {
                atktotal = (randomMinP * cdm) / 100;

            }
            else
            {
                atktotal = (randomMinM * cdm) / 100;
            }
        }
        else
        {
            if (!magicType)
            {
                atktotal = randomMinP;

            }
            else
            {
                atktotal = randomMinM;
            }
        }
        return atktotal;
    }
}
