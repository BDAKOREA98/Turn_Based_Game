using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 5;
    public CharAttributes heroData;


    private void Start()
    {
        StorageMNG.OnClickOnGrayIcon += DestroyMe;
    }

    public abstract void DealsDamage(BattleHex target);

    private void DestroyMe(CharAttributes SOHero)
    {
        if (SOHero == heroData)
        {

            BattleHex parentHex = GetComponentInParent<BattleHex>();
            parentHex.MakeMeDeploymentPosition();
            Destroy(gameObject);
        }

    }


    private void OnDisable()
    {
        StorageMNG.OnClickOnGrayIcon -= DestroyMe;
    }


}
