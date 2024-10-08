﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsNewGround : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.battleHexState
                    == HexState.active
                    && !evaluatedHex.isStartingHex
                    && !evaluatedHex.isIncluded
                    && evaluatedHex.AvailableToGround()
                    && evaluatedHex.GetComponentInChildren<Enemy>() == null;
    }
}
