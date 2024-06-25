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

    
    public List<Hero> DefineAllFighters()
    {
        allFighters = FindObjectsOfType<Hero>().ToList();
        return allFighters;
    }
    public void DefineNewAtacker()
    {
    
        List<Hero> allFighters = DefineAllFighters().
                                 OrderByDescending(hero => hero.heroData.InitiativeCurrent).ToList();
        currentAttacker = allFighters[0];
    }
    public void CleanField()
    {
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            hex.SetDefaultValue();
        }
    }

}
