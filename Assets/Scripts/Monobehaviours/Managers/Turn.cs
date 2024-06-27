using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    BattleController battleController;
    IInitialHexes getInitialHexes = new InitialPos();

    public delegate void StartNewRound();
    public static event StartNewRound OnNewRound;


    private void Start()
    {
        battleController = GetComponent<BattleController>();
      
        
        StartBTN.OnStartingBattle += InitializeNewTurn;
    }

    public void TurnIsCompleted()
    {
        print("next turn");
        StartCoroutine(NextTurnOrGameOver());
    }
    public IEnumerator NextTurnOrGameOver()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        yield return wait;

        List<Hero> allFighters = battleController.DefineAllFighters();


        if(IfThereIsAIRegiment(allFighters) && IfThereIsPlayerRegiment(allFighters))
        {
           NextTurnOrNextRound(allFighters);
        }
        else
        {
            print("Game Over");
        }

    }


    public void InitializeNewTurn()
    {
        battleController.CleanField();
        battleController.DefineNewAttacker();
        Hero currentAttacker = BattleController.currentAttacker;
        
        
        
        GetStartingHex();

        if(currentAttacker.GetComponent<Enemy>() == null)
        {
            IInitialHexes getInitialHexes = new InitialPos();
            currentAttacker.PlayerTurn(getInitialHexes);
        }
        else
        {
            IInitialHexes getInitialHexes = new InitialPosAI();
            currentAttacker.GetComponent<Enemy>().AIturnBegin(getInitialHexes);
        }


    }
    
    private void GetStartingHex()
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex(); 

    }

    bool IfThereIsAIRegiment(List<Hero> allFighters)
    {
        return allFighters.Exists(x => x.gameObject.GetComponent<Enemy>());

    }
    bool IfThereIsPlayerRegiment(List<Hero> allFighters)
    {
        return allFighters.Exists(x => !x.gameObject.GetComponent<Enemy>());
    }

    void NextTurnOrNextRound(List<Hero> allFighters)
    {
        if(allFighters.Exists(x => x.heroData.InitiativeCurrent > 0))
        {
            print("new Turn");
            InitializeNewTurn();
        }
        else
        {
            print("new Round");
            OnNewRound();
            InitializeNewTurn();
        }
    }


}
