using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingAttack : MonoBehaviour, IAttacking
{
    DamageCounter damageController = new DamageCounter();
    int targetStack;

    public void HeroIsDealingDamage(Hero attacker, Hero Target)
    {
        targetStack = damageController.CountTargetStack(attacker, Target);
        int currentInt = Target.heroData.CurrentStack;
        Freeze(Target);

        Target.heroData.CurrentStack = targetStack;
        Target.stack.StartCoroutine(Target.stack.CountDownToTargetStack(currentInt, targetStack));

    }
    void Freeze(Hero Target)
    {
        Target.heroData.CurrentInitiative = 0;
        Target.GetComponent<SpriteRenderer>().color = new Color32(135, 255, 255, 255);

    }

}

    
