using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    int totalDamage;
    int targetTotalHP;
    int targetStack;
    int damagebyUnit;

    int DamageByUnit
    {
        get { return damagebyUnit; }
        set 
        { 
            if(value > 0) 
            {
                damagebyUnit = value; 
            }
            else
            {
                damagebyUnit = 1;
            }
        }
    }


    internal int CountTargetStack(Hero currentAttacker, Hero target)
    {
        totalDamage = CountDamageDealt(currentAttacker, target);

        targetTotalHP = target.heroData.CurrentHP * target.heroData.CurrentStack - totalDamage;

        targetStack = targetTotalHP / target.heroData.CurrentHP;
        return targetStack;

    }





    private int CountDamageDealt(Hero currentAttacker, Hero target)
    {
        DamageByUnit = currentAttacker.heroData.CurrentAttack - target.heroData.CurrentResistance;

        int DamageByRegiment = DamageByUnit * currentAttacker.heroData.CurrentStack;
        return DamageByRegiment;

    }
    



}
