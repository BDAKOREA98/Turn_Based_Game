using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CharIcon : MonoBehaviour
{
    [SerializeField] internal Image heroImage;
    [SerializeField] internal Image backGround;
    [SerializeField] internal TMPro.TextMeshProUGUI stackText;
    [SerializeField] internal CharAttributes charAttributes;

    internal bool deployed = false;


    StorageMNG storage;

    private void Start()
    {
        storage = GetComponentInParent<StorageMNG>();
    }


    internal void FillIcon()
    {
        heroImage.sprite = charAttributes.heroSprite;
        stackText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        

        stackText.text = charAttributes.stack.ToString();
    }

    public void IconClicked()
    {
            
        if (!deployed)
        {
            storage.TintIcon(this);
        }
        else
        {
            storage.ReturnRegiment(this);
        }


    }

    public void HeroIsDeployed()
    {
        backGround.sprite = storage.deployedRegiment;
        deployed = true;
    }

}
