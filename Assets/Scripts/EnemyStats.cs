using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public StatusPlate sp;
    public float hp;
    public float armour;
    public float marmour;
    public float damage;
    public float level;
    struct Resistance{

        public float fire;
        public float thunder;
        public float ice;
        public float dark;
        public float light;
    };
    void Start()
    {
        hp = sp.health;
        if(sp.magtype==true)
        {
            damage = sp.mdamage;
        }
        else
        {
            damage = sp.pdamage;
        }
        armour = sp.armour;
        marmour = sp.marmour;

        PhysArmourPercenatge();
        MagArmourPercenatage();
    }
    void PhysArmourPercenatge()
    {
        armour = armour / (armour + 400f + (85f * level));
        Debug.Log(armour);
    }
    void MagArmourPercenatage()
    {
        marmour = marmour / (marmour + 400f + (85f * level));
        Debug.Log(marmour);
    }
    public void GotHitted(float playerdamage)
    {
        
        if(sp.magtype==true)
        {
            playerdamage = playerdamage - (playerdamage*marmour);
        }
        else
        {
            playerdamage = playerdamage - (playerdamage*armour);
        }
        Debug.Log("Enemy : " + playerdamage + " dmg");
        hp -= playerdamage;
        if(hp<=0)
        {
            Dead();
        }
    }    
    private void Dead()
    {
        Debug.Log("Got Exp!!");
        Destroy(gameObject);
    }    
    
}
