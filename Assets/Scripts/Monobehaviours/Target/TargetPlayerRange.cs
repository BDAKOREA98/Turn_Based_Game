using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerRange : MonoBehaviour, IDefineTarget
{
    BattleHex initialHex;
    List<BattleHex> neighboursToCheck;
    IEvaluateHex checkHex = new IfItIsTarget();
    IInitialHexes getInitialHexes = new InitialTarget();

    Turn turn;
    public void DefineTargets(Hero currentAttacker)
    {
        if (TargetsNearby(currentAttacker) == false)
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
        int stepsLimit = currentAttacker.heroData.Attackdistanse;
        BattleHex inititalHex = currentAttacker.GetComponentInParent<BattleHex>();
        IAdjacentFinder adjFinder = new MarkTargets();
        
        currentAttacker.GetComponent<AvailablePos>().GetAvailablePositions(stepsLimit, adjFinder, getInitialHexes);

        CheckIfItIsNewTurn();

    }

    private void CheckIfItIsNewTurn()
    {
        BattleController battleController = FindObjectOfType<BattleController>();
        if(battleController.IsLookingForPotentialTargets().Count == 0 
            && BattleController.currentAttacker.heroData.CurrentVelocity == 0)
        {
            turn = FindObjectOfType<Turn>();
            turn.TurnIsCompleted();
        }
    }


}
