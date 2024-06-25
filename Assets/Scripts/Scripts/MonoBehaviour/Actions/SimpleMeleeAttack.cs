using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeleeAttack : MonoBehaviour, IAttacking
{
    DamageCounter damageController = new DamageCounter();
    int targetStack;

    public void HeroIsDealingDamage(Hero attacker, Hero target)
    {
        targetStack = damageController.CountTargetStack(attacker, target);
        int currentInt = target.heroData.CurrentStack;

        target.heroData.CurrentStack = targetStack;
        
        target.stack.StartCoroutine(target.stack.CountDownToTargetStack(currentInt, targetStack));

        Debug.Log(target.heroData);
        Debug.Log(attacker.heroData);

    }



}
