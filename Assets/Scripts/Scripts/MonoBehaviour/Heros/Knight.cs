using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Hero
{
    public override void DealsDamage(BattleHex target)
    {

    }

    public override void DefineTargets()
    {
        IDefineTarget wayToLookForTargets = new TargetPlayerMelee();
        wayToLookForTargets.DefineTargets(this);
    }

    public override IAdjacentFinder GetTypeOfHero()
    {
        IAdjacentFinder adjFinder = new PositionsForGround();
        return adjFinder;
    }

}
