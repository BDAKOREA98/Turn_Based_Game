using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleHex targetToMove;
    public static Hero currentAttacker;
    public static Hero currentTarget;
    List<Hero> allFighters = new List<Hero>();
    public int stepsToCheckWholeField;
    public List<BattleHex> potencialTargets = new List<BattleHex>();

    Turn turn;

     void Start()
    {
        turn = GetComponent<Turn>();
    }

    public List<Hero> DefineAllFighters()
    {
        allFighters = FindObjectsOfType<Hero>().ToList();
        return allFighters;
    }
    public void DefineNewAttacker()
    {
    
        List<Hero> allFighters = DefineAllFighters().
                                 OrderByDescending(hero => hero.heroData.InitiativeCurrent).ToList();
        currentAttacker = allFighters[0];
        currentAttacker.heroData.InitiativeCurrent = 0;

    }
    public void CleanField()
    {
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            hex.SetDefaultValue();
        }
    }

    public void RemoveHeroWhenItIsSkilled(Hero hero)
    {
        Destroy(hero.gameObject);
        print(hero.gameObject.name + " is killed");
       // turn.TurnIsCompleted();
    }

    public List<BattleHex> IsLookingForPotentialTargets()
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


}
