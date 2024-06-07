using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFairy : Hero
{
    public override void DealsDamage(BattleHex target)
    {
        
    }
    public override IAdjacentFinder GetTypeOfHero()
    {
        IAdjacentFinder adjFinder = new PositionsForFlying();
        return adjFinder;
    }
}
