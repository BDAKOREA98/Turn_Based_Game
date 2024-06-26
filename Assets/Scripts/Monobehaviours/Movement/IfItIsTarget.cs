using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsTarget : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        

        if(BattleController.currentAttacker.GetComponent<Enemy>() == null)
        {
            return evaluatedHex.GetComponentInChildren<Enemy>() != null;
        }
        else
        {
            return evaluatedHex.GetComponentInChildren<Hero>() != null &&
                evaluatedHex.GetComponentInChildren<Enemy>() == null;
        }

    }

}
