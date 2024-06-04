using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PositionForRegiment { NONE, PLAYER, ENEMY};


public class DeploymentPos : MonoBehaviour
{
    

    public PositionForRegiment regimentPosition;
    



    private void Start()
    {
        
    }


    public void OnMouseDown()
    {
        BattleHex parentHex = GetComponentInParent<BattleHex>();

        if(Deployer.readyForDeploymentIcon != null && regimentPosition == PositionForRegiment.PLAYER)
        {
            Deployer.DeployRegiment(parentHex);
        }

    }


}
