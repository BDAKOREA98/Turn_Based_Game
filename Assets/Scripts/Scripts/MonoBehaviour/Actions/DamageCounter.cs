using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    int totalDamage;
    int targetTotalHP;
    int targetStack;
    int damagebyUnit;

    public int TargetStack
    {
        get { return targetStack; }
        set
        {
            if(value > 0 )
            {
                targetStack = value;
            }
            else
            {
                targetStack = 0;
            }
        }
    }



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

        Debug.Log("TotalDamage");
        Debug.Log(totalDamage);
        targetTotalHP = target.heroData.CurrentHP * target.heroData.CurrentStack;

        Debug.Log("targetBeforeHP");
        Debug.Log(targetTotalHP);
        targetTotalHP = targetTotalHP - totalDamage;

        Debug.Log("targetAfterHP");
        Debug.Log(targetTotalHP);

        TargetStack = targetTotalHP / target.heroData.CurrentHP;

        Debug.Log("CurrentHP");
        Debug.Log(target.heroData.CurrentHP);

        Debug.Log("TargetStack");
        Debug.Log(TargetStack);

        return targetStack;

    }





    private int CountDamageDealt(Hero currentAttacker, Hero target)
    {
        Debug.Log(currentAttacker.heroData);
        Debug.Log(target.heroData);

        DamageByUnit = currentAttacker.heroData.CurrentAttack - target.heroData.CurrentResistance;

        Debug.Log("currentAttackerCurrentAttack");
        Debug.Log(currentAttacker.heroData.CurrentAttack);

        Debug.Log("DamageByUnit");
        Debug.Log(DamageByUnit);

        int DamageByRegiment = DamageByUnit * currentAttacker.heroData.CurrentStack;

        Debug.Log("DamageByRegiment");
        Debug.Log(DamageByRegiment);
        return DamageByRegiment;

    }
    



}
