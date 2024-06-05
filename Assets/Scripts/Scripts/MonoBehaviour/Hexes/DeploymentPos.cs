using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PositionForRegiment { NONE, PLAYER, ENEMY};


public class DeploymentPos : MonoBehaviour
{
    

    public PositionForRegiment regimentPosition;

    BattleHex parentHex;

   


    private void Start()
    {
        parentHex = GetComponentInParent<BattleHex>();
        StartBTN.OnStartingBattle += DisableMe;

    }


    public void OnMouseDown()
    {
        

        if(Deployer.readyForDeploymentIcon != null && regimentPosition == PositionForRegiment.PLAYER)
        {
            Deployer.DeployRegiment(parentHex);
        }

    }

    void DisableMe()
    {
        parentHex.CleanUpDeploymentPosition();
    }


}
