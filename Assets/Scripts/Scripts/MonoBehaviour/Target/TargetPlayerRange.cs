using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerRange : MonoBehaviour, IDefineTarget
{
    BattleHex initialHex;
    List<BattleHex> neighboursToCheck;
    IEvaluateHex checkHex = new IfItIsTarget();
    IInitialHexes getInitialHexes = new InitialTarget();
    public void DefineTargets(Hero currentAtacker)
    {
        if (TargetsNearby(currentAtacker) == false)
        {
            TargetsAtAttackDistance(currentAtacker);
        }
    }

    bool TargetsNearby(Hero currentAtacker)
    {
        bool targetNearby = false;
        initialHex = currentAtacker.GetComponentInParent<BattleHex>();

      
        neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        if (neighboursToCheck.Count == 0)
        {
            return targetNearby;
        }

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
    
    void TargetsAtAttackDistance(Hero currentAtacker)
    {
        int stepsLimit = currentAtacker.heroData.AttackDistanse;
        BattleHex inititalHex = currentAtacker.GetComponentInParent<BattleHex>();
        IAdjacentFinder adjFinder = new MarkTargets();
      
        currentAtacker.GetComponent<AvailablePos>().GetAvailablePositions(stepsLimit, adjFinder, getInitialHexes);
    }
}
