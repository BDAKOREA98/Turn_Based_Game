using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    BattleController battleController;
    IInitialHexes getInitialHexes = new InitialPos();

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

        GetStartingHex();
        currentAttacker.GetComponent<AvailablePos>().GetAvailablePositions(
                                                     stepsLimit, adjFinder, getInitialHexes);

        currentAttacker.DefineTargets();
    }
    
    private void GetStartingHex()
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex(); 
       
    }
}
