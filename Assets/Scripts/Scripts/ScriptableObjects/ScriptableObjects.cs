using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroAttributes", menuName = "Fighter")]

public class ScriptableObjects : ScriptableObject
{
    public int velocity;
    public float initiative;
    public int hp;
    public int atack;
    public int resistance;
    public int stack;

    public Sprite heroSprite;


}
