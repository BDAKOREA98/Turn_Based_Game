﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsNewGroundAI : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.battleHexState
                    == HexState.active
                    && !evaluatedHex.isStartingHex
                    && !evaluatedHex.isIncluded
                    && evaluatedHex.AvailableToGround()
                    && ifThereIsAI(evaluatedHex);

    }
    private bool ifThereIsAI(BattleHex evaluatedHex)
    {
        bool AIPosfalse = true;
        
        if (evaluatedHex.GetComponentInChildren<Hero>() != null &&
            evaluatedHex.GetComponentInChildren<Enemy>() == null)
        {
            AIPosfalse = false;
        }
        return AIPosfalse;
    }
}
