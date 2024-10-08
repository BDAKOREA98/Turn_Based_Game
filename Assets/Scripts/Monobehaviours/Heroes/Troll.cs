﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Hero
{

    IAttacking dealsDamage = new SimpleMeleeAttack();

    public override void DealsDamage(BattleHex target)
    {
        dealsDamage.HeroIsDealingDamage(this, BattleController.currentTarget);
    }
    public override IAdjacentFinder GetTypeOfHero()
    {
        IAdjacentFinder adjFinder = new PosForGroundAI();
        return adjFinder;
    }
    public override void DefineTargets()
    {
     

        BattleHex initialHex = GetComponentInParent<BattleHex>();
        IEvaluateHex checkHex = new IfItIsTarget();

        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        if(neighboursToCheck.Count > 0)
        {
            HeroIsAttacking();
        }
        else
        {
            turn.TurnIsCompleted();
        }


    }

    public override void HeroIsAttacking()
    {
        base.HeroIsAttacking();
        GetComponent<Animator>().SetTrigger("isAttacking");
    }

    public override void HeroIsKilled()
    {
        base.HeroIsKilled();
    }
}
