using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Hero
{
    public override void DealsDamage(BattleHex target)
    {
        
    }

    public override void DefineTargets()
    {
        IDefineTarget wayToLookForTargets = new TargetPlayerRange();
        wayToLookForTargets.DefineTargets(this);
    }


    public override IAdjacentFinder GetTypeOfHero()
    {
        IAdjacentFinder adjFinder = new PositionsForFlying();
        return adjFinder;
    }
}
