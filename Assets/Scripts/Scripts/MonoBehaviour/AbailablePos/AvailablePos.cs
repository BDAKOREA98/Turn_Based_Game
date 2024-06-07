using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePos : MonoBehaviour
{
    private int step;//counts iterations
    List<BattleHex> initialHexes = new List<BattleHex>();//collects neighbouring hexes for evaluated hex
    

    public void GetAvailablePositions(BattleHex startingHex, int stepsLimit, IAdjacentFinder AdjFinder)//looks for all positions available
    {

        AdjFinder.GetAdjacentHexesExtended(startingHex);
        
        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = GetNewInitialHexes();
            foreach (BattleHex hex in initialHexes)
            {
                AdjFinder.GetAdjacentHexesExtended(hex);
                hex.isIncluded = true;
            }
        }
    }
    internal List<BattleHex> GetNewInitialHexes()//collects objects whose neighbours need to be found
    {
        initialHexes.Clear();// empty the array before filling it again
        foreach (BattleHex hex in FieldManager.allHexesArray)
        {
            if (hex.isNeighboringHex & !hex.isIncluded)//eliminates unnecessary hexes
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}
