﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForFlying : MonoBehaviour,IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsNewFlying();
    
    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex,checkHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            hex.isNeighboringHex = true;
            hex.distanceText.SetDistanceForFlyingUnit(initialHex);
            hex.MakeMeAvailable();
        }
    }
}
