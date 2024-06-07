using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum HexState { inactive, active };
public class BattleHex : MonoBehaviour
{
    public int horizontalCoordinate;
    public int verticalCoordinate;
    public HexState battleHexState;
    public bool isSecondLevel = false;
    public ClickOnMe clickOnMe;
    public Image Landscape;
    public Distance distanceText;
    public DeploymentPos deploymentPos;
    [SerializeField] protected Image currentState;
    public bool isStartingHex = false;
    public bool isNeighboringHex = false;
    public bool isIncluded = false;
    public bool potencialTarget;

    private void Awake()
    {
        clickOnMe = GetComponent<ClickOnMe>();
    }
    void Start()
    {

        MakeMeActive();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeMeActive()//sets active state to this hex
    {
        battleHexState = HexState.active;
    }
    public void MakeMeInActive()//sets inactive state to this hex
    {
        if (battleHexState != HexState.active)//excludes manually modified active hexes
        {
            Landscape.color = new Color32(120, 120, 120, 250);//sets new color to an inactive hex
        }

    }
    public virtual void MakeMeAvailable()
    {
        currentState.sprite = clickOnMe.fieldManager.availableToMove;//sets the white frame to a hex
        currentState.color = new Color32(255, 255, 255, 255);
    }
    public virtual void MakeMeTargetToMove()//defines a hex as selected position
    {
        clickOnMe.isTargetToMove = true;
        BattleController.targetToMove = this;

        currentState.sprite = clickOnMe.fieldManager.availableAsTarget;//sets the green frame to a hex
    }
    public void DefineMeAsStartingHex()
    {

        distanceText.distanceFromStartingPoint = 0;
        isStartingHex = true;
        distanceText.stepsToGo = 1;

    }
    public virtual bool AvailableToGround()
    {
        return true;
    }

    public void MakeMeDeploymentPosition()
    {
        deploymentPos.GetComponent<PolygonCollider2D>().enabled = true;
        deploymentPos.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

    }

    public void CleanUpDeploymentPosition()
    {
        deploymentPos.GetComponent<PolygonCollider2D>().enabled = false;
        deploymentPos.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }

    internal void DefineMeAsPotencialTarget()
    {
        currentState.color = new Color(255, 0, 0, 255);
        potencialTarget = true;

    }

    public void SetDefaultValue()
    {
        isStartingHex = false;
        isNeighboringHex = false;
        isIncluded = false;
        distanceText.GetComponent<Text>().color = new Color32(255, 255, 255, 0);
        currentState.color = new Color32(255, 255, 255, 0);
        Landscape.color = new Color32(255, 255, 255, 255);
        //distanceText.stepsToGoCurrent

    }


}
