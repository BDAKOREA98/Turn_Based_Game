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




    void Start()
    {
        hero = GetComponent<Hero>();
        heroSprite = GetComponent<SpriteRenderer>();
        battleController = FindObjectOfType<BattleController>();
    }

    void Update()
    {
        if (isMoving)
            HeroIsMoving();
    }
    public void StartsMoving()
    {
        battleController.events.gameObject.SetActive(false);
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
        transform.position = Vector3.MoveTowards(transform.position, targetPos,
                        speedOfAnim * Time.deltaTime);
        ManageSteps();
    }
    private void ManageSteps()
                              
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f
      && currentStep < totalSteps)//compares the coordinates of hero's current position 
                                  //and the distance to current target position
        {
            currentStep++;//adds one to the value of the currentStep variable
            ResetTargetPos();//sets a new target hex
        }
        else if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            StopsMoving();//stops movement if the hero reaches the end point of movement
        }
    }
    private void StopsMoving()
    {
        isMoving = !isMoving;
        transform.parent = path[currentStep].transform;
        hero.GetComponent<Animator>().SetBool("IsMoving", false);
        hero.heroData.CurrentVelocity = 0;
        hero.DefineTargets();
        battleController.events.gameObject.SetActive(true);

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
