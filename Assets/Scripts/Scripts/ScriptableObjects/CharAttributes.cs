using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeroAttributes", menuName = "Fighter")]
public class CharAttributes : ScriptableObject
{

    [Header("Default Attributes")]
    public int velocity;
    public float initiative;
    public int hp;
    public int attack;
    public int resistance;
    public int stack;

    [SerializeField] int attackDistanse;

    [Header("General Attributes")]
    public bool isRanger;
    public bool isFlying;
    public Sprite heroSprite;
    public Hero heroSO;

    [Header("Current Attributes")]
    float initiativeCurrent;
    public float CurrentInitiative
    {
        get { return initiativeCurrent; }
        set { initiativeCurrent = value; }
    }
    int hpCurrent;
    public int CurrentHP
    {
        get { return hpCurrent; }
        set { hpCurrent = value; }
    }
    int attackCurrent;
    public int CurrentAttack
    {
        get { return attackCurrent; }
        set { attackCurrent = value; }
    }
    int resistanceCurrent;
    public int CurrentResistance
    {
        get { return resistanceCurrent; }
        set { resistanceCurrent = value; }
    }
    int stackCurrent;
    public int CurrentStack
    {
        get { return stackCurrent; }
        set
        {
            if (stackCurrent > 0) { stackCurrent = value; }
            else { stackCurrent = 0; }
        }
    }
    public int AttackDistanse
    {
        get
        {
            if (!isRanger) { return 1; }
            else { return attackDistanse; }
        }
        
    }
    int velocityCurrent;
    public int CurrentVelocity
    {
        get { return velocityCurrent; }
        set { velocityCurrent = value; }
    }
    public void SetCurrentAttributes()
    {
        hpCurrent = hp;
        attackCurrent = attack;
        resistanceCurrent = resistance;
        stackCurrent = stack;
        initiativeCurrent = initiative;
        velocityCurrent = velocity;
    }
}