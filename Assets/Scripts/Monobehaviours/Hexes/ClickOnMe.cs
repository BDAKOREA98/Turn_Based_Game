using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    BattleHex hex;
    public bool isTargetToMove = false;
    public FieldManager fieldManager;
    BattleController battleController;



    void Awake()
    {
        hex = GetComponent<BattleHex>();
        fieldManager = FindObjectOfType<FieldManager>();
        battleController = FindObjectOfType<BattleController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hex.potencialTarget)
        {
            battleController.events.gameObject.SetActive(false);
            BattleController.currentTarget = this.GetComponentInChildren<Hero>();
            BattleController.currentAttacker.HeroIsAttacking();
            return;
        }
        if (!isTargetToMove)
        SelectTargetToMove();
       else
        {
            BattleController.currentAttacker.GetComponent<Move>().StartsMoving();
        }
    }

    private void SelectTargetToMove()
    {
        ClearPreviousSelectionOfTargetHex();
        if (hex.isNeighboringHex)
        {
            hex.MakeMeTargetToMove();
            BattleController.currentAttacker.GetComponent<OptimalPath>().MatchPath();
        }
    }

    public void ClearPreviousSelectionOfTargetHex()
    {
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.clickOnMe.isTargetToMove == true)
            {
                hex.GetComponent<ClickOnMe>().isTargetToMove = false;
                hex.MakeMeAvailable();
            }
            hex.Landscape.color = new Color32(250, 250, 250, 250);
        }
    }
}



