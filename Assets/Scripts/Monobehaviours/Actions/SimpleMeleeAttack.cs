using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeleeAttack : MonoBehaviour, IAttacking
{
    DamageCounter damageController = new DamageCounter();
    int targetStack;
    public void HeroIsDealingDamage(Hero atacker, Hero Target)
    {
        
        targetStack = damageController.CountTargetStack(atacker, Target);
        int currentInt = Target.heroData.CurrentStack;
        
        Target.heroData.CurrentStack = targetStack;
        Target.stack.StartCoroutine(Target.stack.CountDownToTargetStack(currentInt, targetStack));
    }
}
