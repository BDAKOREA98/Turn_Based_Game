using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public bool isMoving = false;
    Hero hero;
    public List<Image> path;
    private int totalSteps;
    private int currentStep;
    Vector3 targetPos;
    float speedOfAnim = 2f;
    
    internal bool lookingToTheRight = true;
    SpriteRenderer heroSprite;
    BattleController battleController;


    private void Start()
    {
        hero = GetComponent<Hero>();
        heroSprite = GetComponent<SpriteRenderer>();
        battleController = FindObjectOfType<BattleController>();    
    }

    private void Update()
    {
        if(isMoving)
        {
            HeroIsMoving();
        }
    }

    public void StartMoving()
    {

        battleController.CleanField();
        currentStep = 0;
        totalSteps = path.Count - 1;

        isMoving = true;
        hero.GetComponent<Animator>().SetBool("IsMoving", true);
        ResetTargetPos();

    }
    


    private void ResetTargetPos()
    {
        targetPos = new Vector3(path[currentStep].transform.position.x,
            path[currentStep].transform.position.y,
            transform.position.z);
        ControlDirection(targetPos);
    }
    private void HeroIsMoving()
    {

        if (targetPos == new Vector3(0,0,0))
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos,
                             speedOfAnim * Time.deltaTime);

        ManageSteps();
    }


    private void ManageSteps()
    {
        if(Vector3.Distance(transform.position,targetPos) < 0.1f
            && currentStep < totalSteps)
        {
            currentStep++;
            ResetTargetPos();
        }
        else if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            StopsMoving();
        }



    }

    private void StopsMoving()
    {
        isMoving = !isMoving;
        transform.parent = path[currentStep].transform;
        hero.GetComponent<Animator>().SetBool("IsMoving", false);
        hero.DefineTargets();


    }
    internal void ControlDirection(Vector3 targetPos)
    {
        
        if (transform.position.x > targetPos.x && lookingToTheRight ||
            transform.position.x < targetPos.x && !lookingToTheRight)
        {
            heroSprite.flipX = !heroSprite.flipX;
            lookingToTheRight = !lookingToTheRight;
        }
    }

  


}
