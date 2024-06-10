using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Stack : MonoBehaviour
{
    Hero parentHero;
    private TextMeshProUGUI stackText; 
    private int stack;
    void Start()
    {
        parentHero = GetComponentInParent<Hero>();
        stackText = GetComponent<TextMeshProUGUI>();
        DisplayCurrentStack();
    }

    public void DisplayCurrentStack()
    {
        
        stack = parentHero.heroData.CurrentStack;
        stackText.text = stack.ToString();
        
    }
}