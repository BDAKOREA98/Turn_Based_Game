using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePos : MonoBehaviour
{
    private int step;
    List<BattleHex> initialHexes = new List<BattleHex>();

    public void GetAvailablePositions(int stepsLimit,
        IAdjacentFinder AdjFinder, IInitialHexes getHexesToCheck)
    {
        BattleHex startingHex = BattleController.currentAttacker.GetComponentInParent<BattleHex>();
        AdjFinder.GetAdjacentHexesExtended(startingHex);
        
        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = getHexesToCheck.GetNewInitialHexes();
            foreach (BattleHex hex in initialHexes)
            {
                AdjFinder.GetAdjacentHexesExtended(hex);
                hex.isIncluded = true;
            }
        }
    }
}
