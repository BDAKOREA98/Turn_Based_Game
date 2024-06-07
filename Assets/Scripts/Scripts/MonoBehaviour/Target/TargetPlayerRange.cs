using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerRange : MonoBehaviour, IDefineTarget
{
    BattleHex initialHex;
    List<BattleHex> neighboursToCheck;
    IEvaluateHex checkHex = new IfItIsTarget();
    IInitialHexes getInitialHexes = new InitialTarget();


    public void DefineTargets(Hero currentAttacker)
    {
        if (TargetsNearby(currentAttacker) == false)//check if there is an enemy nearby
        {
            TargetsAtAttackDistance(currentAttacker);
        }
    }
    bool TargetsNearby(Hero currentAttacker)
    {
        bool targetNearby = false;
        initialHex = currentAttacker.GetComponentInParent<BattleHex>();

        
        neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        if (neighboursToCheck.Count > 0)
        {
            foreach (BattleHex hex in neighboursToCheck)
            {
                hex.DefineMeAsPotencialTarget();
            }
            targetNearby = true;
        }
        return targetNearby;
    }
   
    void TargetsAtAttackDistance(Hero currentAttacker)
    {
        int stepsLimit = currentAttacker.heroData.AttackDistanse;
        BattleHex inititalHex = currentAttacker.GetComponentInParent<BattleHex>();
        IAdjacentFinder adjFinder = new MarkTargets();
        
        currentAttacker.GetComponent<AvailablePos>().GetAvailablePositions( stepsLimit, adjFinder, getInitialHexes);
    }

}