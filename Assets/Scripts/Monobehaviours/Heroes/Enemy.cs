using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BattleController battleController;
    AllPosForGroundAI toCheckTheField;
    private void Start()
    {
        battleController = FindObjectOfType<BattleController>();
        toCheckTheField = GetComponent<AllPosForGroundAI>();

    }

    public void AIturnBegin(IInitialHexes getInitialHex)
    {
        int stepsLimit = battleController.stepsToCheckWholeField;
        BattleHex startHex = GetComponentInParent<BattleHex>();
        toCheckTheField.GetAvailablePositions(stepsLimit, getInitialHex, startHex);

    }


}
