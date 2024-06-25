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
        IInitialHexes getInitialHexes = new InitialPos();
        
        StartBTN.OnStartingBattle += InitializeNewTurn;
    }
    public void InitializeNewTurn()
    {
        battleController.DefineNewAtacker();
        Hero currentAtacker = BattleController.currentAttacker;
        IAdjacentFinder adjFinder = currentAtacker.GetTypeOfHero();
        int stepsLimit = currentAtacker.heroData.CurrentVelocity;
        GetStartingHex();
        
        currentAtacker.GetComponent<AvailablePos>().GetAvailablePositions(stepsLimit, adjFinder, getInitialHexes);

        currentAtacker.DefineTargets();
    }
    
    private void GetStartingHex()
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex(); 

    }
}
