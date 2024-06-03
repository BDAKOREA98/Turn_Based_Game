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





    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        CallHeroIcons();
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

    internal void ReturnRegiment(CharIcon clickedIcon)
    {

    }



}
