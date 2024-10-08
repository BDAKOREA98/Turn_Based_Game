using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPosForGroundAI : MonoBehaviour
{
    private int step;
    List<BattleHex> initialHexes = new List<BattleHex>();
    IEvaluateHex checkHex = new IfAILooksforAllTargets();

    public void GetAvailablePositions(int stepsLimit, IInitialHexes getHexesToCheck, BattleHex startingHex)
    {
        GetAdjacentHexesExtended(stepsLimit, startingHex);

        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = getHexesToCheck.GetNewInitialHexes();
            foreach (BattleHex hex in initialHexes)
            {
                
                    GetAdjacentHexesExtended(stepsLimit, hex);
                
            }
        }
    }

    public void GetAdjacentHexesExtended(int stepsLimit, BattleHex initialHex)
    {
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            if (hex.distanceText.EvaluateDistanceForGroundAI(initialHex, stepsLimit))
            {
                hex.isNeighboringHex = true;
                hex.distanceText.SetDistanceForGroundUnit(initialHex);

            }
        }



    }


}
