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
    BattleController battleController;
    internal Turn turn;
    private void Awake()
    {
        heroData.SetCurrentAttributes();
        moveCpmnt = GetComponent<Move>();
        battleController = FindObjectOfType<BattleController>();
        turn = FindObjectOfType<Turn>();
    }
    private void Start()
    {
        StorageMNG.OnClickOnGrayIcon += DestroyMe; 
        startBTN = FindObjectOfType<StartBTN>();
        stack = GetComponentInChildren<Stack>();
        Turn.OnNewRound += heroData.SetDefaultVelocityAndInitiative;


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
    void OnDisable()
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

    public void PlayerTurn(IInitialHexes getInitialHexes)
    {
        IAdjacentFinder adjFinder = GetTypeOfHero();
        int stepsLimit = heroData.CurrentVelocity;

        GetComponent<AvailablePos>().GetAvailablePositions(stepsLimit, adjFinder, getInitialHexes);
        DefineTargets();

    }

    public void HeroIsKilled()
    {
        Turn.OnNewRound -= heroData.SetDefaultVelocityAndInitiative;
        battleController.RemoveHeroWhenItIsSkilled(this);
    }


}
