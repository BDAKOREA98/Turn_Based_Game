using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerMelee : MonoBehaviour, IDefineTarget
{
    BattleHex initialHex;
    List<BattleHex> neighboursToCheck;
    IEvaluateHex checkHex = new IfItIsTarget();

    public void DefineTargets(Hero currentAttacker)
    {
    
        initialHex = currentAttacker.GetComponentInParent<BattleHex>();
        
        neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            hex.DefineMeAsPotencialTarget();
        }



    }


}
