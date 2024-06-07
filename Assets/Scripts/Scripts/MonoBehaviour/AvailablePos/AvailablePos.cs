using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePos : MonoBehaviour
{
    private int step;//counts iterations
    List<BattleHex> initialHexes = new List<BattleHex>();//collects neighbouring hexes for evaluated hex
    

    public void GetAvailablePositions( int stepsLimit, IAdjacentFinder AdjFinder, IInitialHexes GetHexesToCheck)//looks for all positions available
    {
        BattleHex startingHex =  BattleController.currentAttacker.GetComponentInParent<BattleHex>();

        AdjFinder.GetAdjacentHexesExtended(startingHex);
        
        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = GetHexesToCheck.GetNewInitialHexes();
            foreach (BattleHex hex in initialHexes)
            {
                AdjFinder.GetAdjacentHexesExtended(hex);
                hex.isIncluded = true;
            }
        }
    }
    internal List<BattleHex> GetNewInitialHexes()//collects objects whose neighbours need to be found
    {
        initialHexes.Clear();
        foreach (BattleHex hex in FieldManager.allHexesArray)
        {
            if (hex.isNeighboringHex & !hex.isIncluded)
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }

}
