using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    BattleController battleController;
    IInitialHexes getInitialHexes = new InitialPos();

   

    public delegate void StartNewRound();
    public static event StartNewRound OnNewRound;

    [SerializeField] GameOver gameOverPanel;
    FieldManager parent;


    private void Start()
    {
        battleController = GetComponent<BattleController>();
      
        
        StartBTN.OnStartingBattle += InitializeNewTurn;
        parent = FindObjectOfType<FieldManager>();
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

        battleController.events.gameObject.SetActive(true);

        List<Hero> allFighters = battleController.DefineAllFighters();


        if(IfThereIsAIRegiment(allFighters) && IfThereIsPlayerRegiment(allFighters))
        {
             NextTurnOrNextRound(allFighters);
        }
        else
        {
            battleController.CleanField();
            GameOver gameOver = Instantiate(gameOverPanel, parent.transform);
            gameOver.DefeatOrVictory(IfThereIsPlayerRegiment(allFighters));
            RemoveAllHeroes(allFighters);
        }

    }

    void RemoveAllHeroes(List<Hero> allFighters)
    {
        foreach(Hero hero in allFighters)
        {
            Destroy(hero.gameObject);
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
