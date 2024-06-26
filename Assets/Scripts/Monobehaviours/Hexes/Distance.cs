using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int distanceFromStartingPoint;
    public int stepsToGo;
    public int defaoutDistance;
    public int defaultstepsToGo;



    BattleHex hex;
    Text distanceText; 

    private void Start()
    {
        hex = GetComponentInParent<BattleHex>();
        distanceText = GetComponent<Text>();
    }
   
    public void SetDistanceForGroundUnit(BattleHex initialHex)
    {
   
        distanceFromStartingPoint = initialHex.distanceText.distanceFromStartingPoint
                    + initialHex.distanceText.stepsToGo;
   
        DisplayDistanceText();
    }
    public void SetDistanceForFlyingUnit(BattleHex initialHex)
    {
       
        distanceFromStartingPoint = initialHex.distanceText.distanceFromStartingPoint + 1;
       
        DisplayDistanceText();
    }

    private void DisplayDistanceText()
    {
        distanceText.text = distanceFromStartingPoint.ToString();
        distanceText.color = new Color32(255, 255, 255, 255);
    }

    public bool EvaluateDistance(BattleHex initialHex)
    {
        return distanceFromStartingPoint + stepsToGo ==
                initialHex.distanceText.distanceFromStartingPoint;
    }
    public int MakeMePartOfOptimalPath()
    
    {
        OptimalPath.optimalPath.Add(hex);
        hex.Landscape.color = new Color32(150, 150, 150, 255);
        return stepsToGo;
    }
    public bool EvaluateDistanceForGround(BattleHex initialHex)
    {
    
        int currentDistance = initialHex.distanceText.distanceFromStartingPoint
                              + initialHex.distanceText.stepsToGo;
        int stepsLimit = BattleController.currentAttacker.heroData.CurrentVelocity;
        
        return distanceFromStartingPoint > currentDistance &&
                stepsLimit >= currentDistance;
    }

    public bool EvaluateDistanceForGroundAI(BattleHex initialHex, int stepsLimit)
    {

        int currentDistance = initialHex.distanceText.distanceFromStartingPoint
                              + initialHex.distanceText.stepsToGo;
        

        return distanceFromStartingPoint > currentDistance &&
                stepsLimit >= currentDistance;
    }
}
