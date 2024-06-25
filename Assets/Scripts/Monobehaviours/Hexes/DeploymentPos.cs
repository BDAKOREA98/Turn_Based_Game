using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionForRegiment { none, player, enemy };
public class DeploymentPos : MonoBehaviour
{
    public PositionForRegiment regimentPosition;
    BattleHex parentHex;
    void Start()
    {
        parentHex = GetComponentInParent<BattleHex>();
        StartBTN.OnStartingBattle += DisableMe;
    }

    public void OnMouseDown()
    {       
        
        if (Deployer.readyForDeploymentIcon != null && regimentPosition ==PositionForRegiment.player)
        {
            Deployer.DeployRegiment(parentHex);
        }
    }
    void DisableMe()
    {
        parentHex.CleanUpDeploymentPosition();
    }

}
