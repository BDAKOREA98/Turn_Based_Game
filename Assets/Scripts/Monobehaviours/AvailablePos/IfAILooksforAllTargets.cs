using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfAILooksforAllTargets : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.battleHexState == HexState.active
            && !evaluatedHex.isStartingHex
            && evaluatedHex.AvailableToGround();

    }
}
