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
        Hero currentAttacker = BattleController.currentAttacker;
        
        
        
        GetStartingHex();

        if(currentAttacker.GetComponent<Enemy>() == null)
        {
            currentAttacker.PlayerTurn(getInitialHexes);
        }
        else
        {
            currentAttacker.GetComponent<Enemy>().AIturnBegin(getInitialHexes);
        }


    }
    
    private void GetStartingHex()
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex(); 

    }
}
