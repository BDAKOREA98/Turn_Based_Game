using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    int totalDamage;
    int targetTotalHP;
    int targetStack;
    public int TargetStack
    {
        get { return targetStack; }
        set
        {
            if (value > 0) { targetStack = value; }
            else { targetStack = 0; }
        }
    }
    int damagebyUnit;
    int DamageByUnit
    {
        get { return damagebyUnit; }
        set
        {
            if (value > 0) { damagebyUnit = value; }
            else { damagebyUnit = 1; }
        }
    }

    
    internal int CountTargetStack(Hero currentAtacker, Hero target)
    {
        totalDamage = CountDamageDealt(currentAtacker, target); 

        
        targetTotalHP = target.heroData.CurrentHP * target.heroData.CurrentStack - totalDamage;

        
        TargetStack = targetTotalHP / target.heroData.CurrentHP;
        return targetStack;
    }

    
    private int CountDamageDealt(Hero currentAttacker, Hero target)
    {
     
        DamageByUnit = currentAttacker.heroData.CurrentAttack - target.heroData.CurrentResistance;
     
        int DamageByRegiment = DamageByUnit * currentAttacker.heroData.CurrentStack;
        return DamageByRegiment;
    }
}
