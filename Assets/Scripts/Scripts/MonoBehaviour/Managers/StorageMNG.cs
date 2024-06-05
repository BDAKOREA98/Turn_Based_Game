using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StorageMNG : MonoBehaviour
{
    [SerializeField] internal CurrentProgress currentProgress;
    [SerializeField] CharIcon iconPrefab;
    List<CharAttributes> regimentIcons = new List<CharAttributes>();
    ScrollRect scrollRect;

    [SerializeField] internal Sprite selectedIcon;
    [SerializeField] internal Sprite defaultIcon;
    [SerializeField] internal Sprite deployedRegiment;

    public static event Action<CharAttributes> OnRemoveHero;
    public delegate void DeleteHero(CharAttributes SOofHero);
    public static event DeleteHero OnClickOnGrayIcon;
    public CharIcon[] charIcons;



    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        CallHeroIcons();

        StartBTN.OnStartingBattle += DisableMe;
        charIcons = GetComponentsInChildren<CharIcon>();
    }

    private void CallHeroIcons()
    {
        regimentIcons = currentProgress.heroesOfPlayer;

        Transform parentOfIcon = scrollRect.content.transform;

        for (int i = 0; i < regimentIcons.Count; i++)
        {
            CharIcon fighterIcon = Instantiate(iconPrefab, parentOfIcon);
            fighterIcon.charAttributes = regimentIcons[i];
            fighterIcon.FillIcon();


        }

    }
    

    internal void TintIcon(CharIcon clickedIcon)
    {
        CharIcon[] charIcons = GetComponentsInChildren<CharIcon>();
        
        


        foreach (CharIcon Icon in charIcons)
        {
            if (!Icon.deployed)
            {
                Icon.backGround.sprite = defaultIcon;
            }

        }

        clickedIcon.backGround.sprite = selectedIcon;
        Deployer.readyForDeploymentIcon = clickedIcon;


    }



    private void RemoveHero(Hero hero)
    {
        BattleHex parentHex = hero.GetComponentInParent<BattleHex>();
        parentHex.MakeMeDeploymentPosition();

        Destroy(hero.gameObject);

    }


    public void RemoveRegiment(CharAttributes SOHero)
    {
        OnClickOnGrayIcon(SOHero);
    }

    private void DisableMe()
    {
        gameObject.SetActive(false); 
    }


    //internal void ReturnRegiment(CharIcon clickedIcon)
    //{

    //    CharAttributes SOofRegiment = clickedIcon.charAttributes;

    //    Hero[] regimentsOnBattleField = FindObjectsOfType<Hero>();

    //    foreach (Hero hero in regimentsOnBattleField)
    //    {
    //        if (hero.heroData == SOofRegiment)
    //        {
    //            RemoveHero(hero);

    //            break;
    //        }


    //    }

    //}

}
