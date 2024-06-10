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
        target.heroData.CurrentStack = targetStack;
        target.stack.DisplayCurrentStack();


    }



}
