using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero
{
     [SerializeField] Arrow arrow;
     [SerializeField] internal  Vector3 initialPosCorrection;


    public override void DealsDamage(BattleHex target)
    {
        
    }

    public override IAdjacentFinder GetTypeOfHero()
    {
        IAdjacentFinder adjFinder = new PositionsForGround();
        return adjFinder;
    }
    public override void DefineTargets()
    {
        IDefineTarget wayToLookForTargets = new TargetPlayerRange();
        wayToLookForTargets.DefineTargets(this);
    }

    public override void HeroIsAttacking() 
    {
        base.HeroIsAttacking();
        GetComponent<Animator>().SetTrigger("isAttacking");
        InstantiateArrow();
    }

    private void InstantiateArrow()
    {
        Vector3 positionForArrow = new Vector3(transform.position.x,
            transform.position.y + initialPosCorrection.y, transform.position.z);

        Hero currentTarget = BattleController.currentTarget.GetComponent<Hero>();
        
        Quaternion rotation = CalcRotation.CalculateRotation(currentTarget);
        Arrow Arrow = Instantiate(arrow, positionForArrow, rotation, transform);

        Arrow.FireArrow();

    }
}
