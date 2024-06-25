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
    static public List<BattleHex> GetAdjacentHexes(BattleHex startingHex, IEvaluateHex checkHex)
    {
        allNeighbours.Clear();
        
        int initialX = startingHex.horizontalCoordinate - 1; 
        int initialY = startingHex.verticalCoordinate - 1;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x + y != 0 
                     && checkHex.EvaluateHex(FieldManager.allHexesArray[initialX + x, initialY + y]))  
                {
                    allNeighbours.Add(FieldManager.allHexesArray[initialX + x, initialY + y]);
                }
            }
        }


        
        Debug.Log(FieldManager.allHexesArray.Length);

        return allNeighbours;


    }
}
