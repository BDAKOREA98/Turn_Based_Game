using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleHex targetToMove;
    public static Hero currentAttacker;
    List<Hero> allFighters = new List<Hero>(); 

    
    public List<Hero> DefineAllFighters()
    {
        allFighters = FindObjectsOfType<Hero>().ToList();
        return allFighters;
    }
    public void DefineNewAtacker()
    {
     
        List<Hero> allFighters = DefineAllFighters().
                                 OrderByDescending(hero => hero.heroData.CurrentInitiative).ToList();
     
        currentAttacker = allFighters[0];

        
    }

}
