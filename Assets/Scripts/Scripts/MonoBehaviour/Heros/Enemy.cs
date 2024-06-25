using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BattleController battleController;
    AllPosForGroundAI tocheckTheField;
    void Start()
    {
        battleController = FindObjectOfType<BattleController>();
        tocheckTheField = GetComponent<AllPosForGroundAI>();
    }

    
    public void AIsTurnBegin(IInitialHexes getInitialHexes)
    {
        int stepsLimit = battleController.stepsToCheckWholeField;;
        BattleHex startintHex = GetComponentInParent<BattleHex>();
        tocheckTheField.GetAvailablePositions(stepsLimit, getInitialHexes, startintHex);
    }

}
