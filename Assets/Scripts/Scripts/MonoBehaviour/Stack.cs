using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Stack : MonoBehaviour
{
    Hero parentHero;
    private TextMeshProUGUI stackText;
    private int _stack;
    internal int currentStack
    {
        get { return _stack; }
        set
        {
            if (value > 0)
            {
                _stack = value;
            }
            else
            {
                _stack = 0;
            }
        }
    }

    private void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        stackText = GetComponent<TextMeshProUGUI>();
        DisplayInitialStack();
    }

    void DisplayInitialStack()
    {
        currentStack = parentHero.heroData.stack;   
        stackText.text = currentStack.ToString();
    }

}
