using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    internal Vector3 targetPosition;
    [SerializeField] Vector3 targetPosAdj;
    internal bool ArrowFlies = false;
    [SerializeField] float velocity;
    IAttacking dealsDamage = new SimpleMeleeAttack();
   
    
    private void Update()
    {
        if(ArrowFlies)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                targetPosition, velocity * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                ArrowFlies = false;
                Hero currentTarget = BattleController.currentTarget;
                dealsDamage.HeroIsDealingDamage(BattleController.currentAttacker, currentTarget);
                //currentTarget.GetComponent<Animator>().
                DestroyMe();
            }
        }
        

    }

    public void FireArrow()
    {
        Vector3 currentTargetPos = BattleController.currentTarget.transform.position;
        targetPosition = currentTargetPos + targetPosAdj;
        ArrowFlies = true;

    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }



}
