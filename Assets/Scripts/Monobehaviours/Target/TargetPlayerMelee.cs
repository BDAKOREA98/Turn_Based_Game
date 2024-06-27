using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerMelee : MonoBehaviour, IDefineTarget
{
    BattleHex initialHex;
    List<BattleHex> neighboursToCheck;
    IEvaluateHex checkHex = new IfItIsTarget();
    Turn turn;
    
    public void DefineTargets(Hero currentAtacker)
    {
        initialHex = currentAtacker.GetComponentInParent<BattleHex>();

        neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);

        int currentAttackerVelocity = BattleController.currentAttacker.heroData.CurrentVelocity;

        if(neighboursToCheck.Count > 0)
        {
            foreach (BattleHex hex in neighboursToCheck)
            {
                hex.DefineMeAsPotencialTarget();
            }

        }
        else if(neighboursToCheck.Count == 0 && currentAttackerVelocity == 0)
        {
            turn = FindObjectOfType<Turn>();
            turn.TurnIsCompleted();
        }

        
        
    }
}
