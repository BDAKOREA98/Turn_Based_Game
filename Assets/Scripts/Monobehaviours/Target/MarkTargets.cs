using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkTargets : IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsTargetRange();
    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);

        foreach (BattleHex hex in neighboursToCheck)
        {
            hex.lookingForTarget = true;
            if (hex.GetComponentInChildren<Enemy>() != null)
            {
                hex.DefineMeAsPotencialTarget();
            }
        }
    }
}
