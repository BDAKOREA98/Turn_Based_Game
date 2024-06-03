using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentPos : MonoBehaviour
{
    public bool positionForRegiment;





    private void Start()
    {
        
    }


    public void OnMouseDown()
    {
        BattleHex parentHex = GetComponentInParent<BattleHex>();

        if(Deployer.readyForDeploymentIcon != null && positionForRegiment)
        {
            Deployer.DeployRegiment(parentHex);
        }

    }


}
