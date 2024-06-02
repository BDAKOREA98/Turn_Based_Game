using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    BattleHex hex;
    public bool isTargetHex = false;//becomes true when the hex is clicked
    public FieldManager fieldManager;

    void Awake()
    {
        hex = GetComponent<BattleHex>();
        fieldManager = FindObjectOfType<FieldManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClearPreviousSelectionOfTargetHex();
        if (hex.isNeighboringHex)
        {
            print("선택된 타일");
            Debug.Log(hex.verticalCoordinate);
            Debug.Log(hex.horizontalCoordinate);
            Debug.Log("타겟확인");
            Debug.Log(hex.clickOnMe.isTargetHex);
            hex.MakeMeTargetToMove();
        }
}

    public void ClearPreviousSelectionOfTargetHex()//Cancels previous selection
    {
        foreach (BattleHex hex in FieldManager.activeHexList)//looks for selected hex in active hexes list
        {
            if (hex.clickOnMe.isTargetHex == true)//evaluates hex if it is target
            {
                hex.GetComponent<ClickOnMe>().isTargetHex = false;//overrides boolean
                hex.MakeMeAvailable();// sets white frame
            }
        }
    }
}



