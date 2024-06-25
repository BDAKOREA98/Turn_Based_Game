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
        GetStartingHex();
        
        if(currentAttacker.GetComponent<Enemy>() == null)
        {
            currentAttacker.PlayersTurn(getInitialHexes);
        }
        else
        {
            currentAttacker.GetComponent<Enemy>().AIsTurnBegin(getInitialHexes);
        }





    }
    
    private void GetStartingHex()
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex(); 
       
    }
}
