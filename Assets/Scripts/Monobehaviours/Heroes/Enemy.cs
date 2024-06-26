using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BattleController battleController;
    AllPosForGroundAI toCheckTheField;
    public List<BattleHex> potencialTargets = new List<BattleHex>();
    public List<BattleHex> posToOccupy = new List<BattleHex>();
    List<BattleHex> allTargets = new List<BattleHex>();
    List<BattleHex> closeTargets = new List<BattleHex>();
    BattleHex hexToOccupy;
    AvailablePos availablePos;
    Move move;
    Hero hero;

    private void Start()
    {
        battleController = FindObjectOfType<BattleController>();
        toCheckTheField = GetComponent<AllPosForGroundAI>();


        hero = GetComponent<Hero>();
        availablePos = GetComponent<AvailablePos>();
        move = GetComponent<Move>();
        move.lookingToTheRight = false;

    }

    public void AIturnBegin(IInitialHexes getInitialHex)
    {
        int stepsLimit = battleController.stepsToCheckWholeField;
        BattleHex startHex = GetComponentInParent<BattleHex>();
        
        toCheckTheField.GetAvailablePositions(stepsLimit, getInitialHex, startHex);

        CollectAllPosToOccupy();
        //AISelectsTargetToAttack();
       
        AIMakesDecision();
        AISelectsPosToOCuppy();
        
    }

    private List<BattleHex> CollectAllPosToOccupy()
    {
        posToOccupy.Clear();
        foreach(BattleHex hex in FieldManager.activeHexList)
        {
            if(hex.distanceText.distanceFromStartingPoint <= hero.heroData.CurrentVelocity)
            {
                posToOccupy.Add(hex);

            }

        }
        return posToOccupy;

    }

    private List<BattleHex> AIIsLookingForPotentialTargets()
    {
        potencialTargets.Clear();

        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.potencialTarget)
            {
                potencialTargets.Add(hex);

            }

        }
        return potencialTargets;


    }

    private List<BattleHex> CheckIfAttackIsAvailable()
    {
        int currentVelocity = BattleController.currentAttacker.heroData.CurrentVelocity;

        closeTargets.Clear();

        List<BattleHex> allTargets = AIIsLookingForPotentialTargets();

        foreach(BattleHex hex in allTargets)
        {
            if(hex.distanceText.distanceFromStartingPoint <= currentVelocity +1 )
            {
                closeTargets.Add(hex);
            }
        }
        return closeTargets;


    }


    public BattleHex AISelectsTargetToAttack()
    {
        allTargets.Clear();

        if(CheckIfAttackIsAvailable().Count > 0)
        {
            allTargets = CheckIfAttackIsAvailable().OrderBy(hero => hero.GetComponentInChildren<Hero>().heroData.CurrentHP).ToList();

        }
        else
        {
            allTargets = AIIsLookingForPotentialTargets().OrderBy(hero => hero.distanceText.distanceFromStartingPoint).
                ThenBy(hero => hero.GetComponentInChildren<Hero>().heroData.CurrentHP).ToList();
        }
        BattleController.currentTarget = allTargets[0].GetComponentInChildren<Hero>();
        Debug.Log(allTargets[0].GetComponentInChildren<Hero>().gameObject.name);
        return allTargets[0];

    }

    private void AIStartMoving(BattleHex targetToAttack)
    {
        battleController.CleanField();
        targetToAttack.DefineMeAsStartingHex();
        int stepsLimit = battleController.stepsToCheckWholeField;
        IInitialHexes getInitialHexes = new InitialPos();

        toCheckTheField.GetAvailablePositions(stepsLimit, getInitialHexes, targetToAttack);
        IAdjacentFinder adjFinder = BattleController.currentAttacker.GetTypeOfHero();
        AIDefinePath(adjFinder);

    }

    private BattleHex AISelectsPosToOCuppy()
    {
        List<BattleHex> OrderedPos = posToOccupy.OrderBy(s => s.distanceText.distanceFromStartingPoint).ToList();

         for (int i = 0; i < OrderedPos.Count; i++)
        {
            if(OrderedPos[i].GetComponentInChildren<Hero>() == null)
            {
                hexToOccupy = OrderedPos[i];
                break;
            }

        }

       
        return hexToOccupy;

    }    



    void AIMakesDecision()
    {
        BattleHex targetToAttack = AISelectsTargetToAttack();

        if(targetToAttack.distanceText.distanceFromStartingPoint > 1)
        {
            AIStartMoving(targetToAttack);
        }
        else
        {
            hero.HeroIsAtacking();
        }

    }

    private void AIDefinePath(IAdjacentFinder adjFinder)
    {
        BattleController.targetToMove = AISelectsPosToOCuppy();
        battleController.CleanField();
        IInitialHexes getInitialHexes = new InitialPos();
        int stepsLimit = hero.heroData.CurrentVelocity;
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        startingHex.DefineMeAsStartingHex();

        availablePos.GetAvailablePositions(stepsLimit, adjFinder, getInitialHexes);
        GetComponent<OptimalPath>().MatchPath();
        move.StartsMoving();




    }





}
