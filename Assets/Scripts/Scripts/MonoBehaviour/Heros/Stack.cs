using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Stack : MonoBehaviour
{
    Hero parentHero;
    private TextMeshProUGUI stackText; 
    private int stack;

    [SerializeField] float iterationCntrl;

    int iterationVal;
    public int IterationVal
    {
        get { return iterationVal; }
        set
        {
            if(value < 1)
            {
                iterationVal = 1;
            }    
            else
            {
                iterationVal = value;
            }
        }
    }


    void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        stackText = GetComponent<TextMeshProUGUI>();
        DisplayCurrentStack(parentHero.heroData.CurrentStack       );

    }

    public void DisplayCurrentStack(int currentStack)
    {
        
        stack = parentHero.heroData.CurrentStack;
        stackText.text = currentStack.ToString();
        
    }



    public IEnumerator CountDownToTargetStack(int currentValue, int targetValue)
    {
        int diff = currentValue - targetValue;

        IterationVal = Mathf.FloorToInt(diff * Time.deltaTime / iterationCntrl);
        WaitForSeconds wait = new WaitForSeconds(0.01f);

        while(currentValue >= targetValue + IterationVal)
        {
            currentValue -= IterationVal;
            DisplayCurrentStack(currentValue);
            yield return wait;
        }
        DisplayCurrentStack(currentValue);
    }


    
}