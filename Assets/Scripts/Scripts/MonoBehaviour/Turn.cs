using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    BattleController battleController;

    private void Start()
    {
        battleController = GetComponent<BattleController>();

        StartBTN.OnStartingBattle += InitializeNewTurn;
    }
    public void InitializeNewTurn()
    {
        battleController.DefineNewAtacker();
        Hero currentAttacker = BattleController.currentAttacker;
        IAdjacentFinder adjFinder = currentAttacker.GetTypeOfHero();
        int stepsLimit = currentAttacker.heroData.CurrentVelocity;

        
        currentAttacker.GetComponent<AvailablePos>().GetAvailablePositions(GetStartingHex(),
                                                     stepsLimit, adjFinder);
    }
    
    private BattleHex GetStartingHex()
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex(); 
        return startingHex;
    }
}
