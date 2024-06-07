using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartBTN : MonoBehaviour
{
    [SerializeField] Button startBTN;
    StorageMNG storage;
    public delegate void StartsBattle();
    public static event StartsBattle OnStartingBattle;
    [SerializeField] int minimumHeroesNum;



    private void Start()
    {
        storage = GetComponent<StorageMNG>();
        OnStartingBattle += ControlStartBTN;
        startBTN.gameObject.SetActive(false);
    }

    public void StartBattle()
    {
        OnStartingBattle();
    }


    public void ControlStartBTN()
    {
        int deployedReg = GetGrayIcons();

        if (deployedReg >= minimumHeroesNum)
        {
            startBTN.gameObject.SetActive(true);

        }
        else
        {
            startBTN.gameObject.SetActive(false);
        }
    }


    int GetGrayIcons()
    {
        int grayIcons = 0;

        foreach (CharIcon icon in storage.charIcons)
        {

            if (icon.deployed)
            {
                grayIcons++;
            }


        }

        return grayIcons;

    }
}
