using System.Collections;
using System.Collections.Generic;
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
    public bool isNeighboringHex = false;//helps to define a hex as neighbouring to evaluated
    public bool isIncluded = false;//helps to define a hex as available position

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




}
