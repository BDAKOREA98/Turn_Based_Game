using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighboursFinder : MonoBehaviour
{
    static private BattleHex startingHex;
    static List<BattleHex> allNeighbours = new List<BattleHex>();
    private FieldManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    static public List<BattleHex> GetAdjacentHexes(BattleHex startingHex)//Looks for and returns neighbouring hexes
    {
        allNeighbours.Clear();

        //subtract 1 since array's index starts from 1. 
        int initialX = startingHex.horizontalCoordinate - 1; //first index for two-dimensional list
        int initialY = startingHex.verticalCoordinate - 1;//second index for two-dimensional list
        //iterates x and y from -1 to 1 to get adjacent hexes referring to the coordinates of starting hex
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x + y != 0 //exclude two hexes that are not adjacent hexes
                     && EvaluateIfItIsNewHex(FieldManager.allHexesArray[initialX + x, initialY + y])) //exclude inactive hexes                       
                {
                    allNeighbours.Add(FieldManager.allHexesArray[initialX + x, initialY + y]);
                    FieldManager.allHexesArray[initialX + x, initialY + y].MakeMeAvailable();
                }
            }
        }
        return allNeighbours;
    }
   //evaluates the state of a hex (active, included and neighbouring)
    private static bool EvaluateIfItIsNewHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.battleHexState
                            == HexState.active
                            && !evaluatedHex.isStartingHex
                            && !evaluatedHex.isNeighboringHex;
    }
}
