using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 5;
    public CharAttributes heroData;
    StartBTN startBTN;
    public Stack stack;
    Move moveCpmnt;

    private void Awake()
    {
        heroData.SetCurrentAttributes();
        moveCpmnt = GetComponent<Move>();
    }
    private void Start()
    {
        StorageMNG.OnClickOnGrayIcon += DestroyMe;
        startBTN = FindObjectOfType<StartBTN>();
        stack = GetComponentInChildren<Stack>();

    }

    public abstract void DealsDamage(BattleHex target);

    private void DestroyMe(CharAttributes SOHero)
    {
        if (SOHero == heroData)
        {

            BattleHex parentHex = GetComponentInParent<BattleHex>();
            parentHex.MakeMeDeploymentPosition();
            startBTN.ControlStartBTN();
            Destroy(gameObject);
        }

    }


    private void OnDisable()
    {
        StorageMNG.OnClickOnGrayIcon -= DestroyMe;
    }

    public abstract IAdjacentFinder GetTypeOfHero();
    public abstract void DefineTargets();

    public virtual void HeroIsAttacking() 
    {
        Vector3 targetPos = BattleController.currentTarget.transform.position;
        moveCpmnt.ControlDirection(targetPos);
    }


    public void PlayersTurn(IInitialHexes getInitialHexes)
    {
        IAdjacentFinder adjFinder = GetTypeOfHero();
        int stepsLimit = heroData.CurrentVelocity;

        GetComponent<AvailablePos>().GetAvailablePositions(stepsLimit, adjFinder, getInitialHexes);
        DefineTargets();
    }


}
