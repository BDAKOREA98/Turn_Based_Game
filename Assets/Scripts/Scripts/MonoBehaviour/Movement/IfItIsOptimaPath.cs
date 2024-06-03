using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsOptimaPath : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.isNeighboringHex;

    }
}
