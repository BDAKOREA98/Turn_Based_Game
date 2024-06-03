using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
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
        StorageMNG.OnRemoveHero += ReturnDefaultState;

    }

    

    internal void FillIcon()
    {
        heroImage.sprite = charAttributes.heroSprite;
        stackText = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        
        stackText.text = charAttributes.stack.ToString();
    }

    public void IconClicked()
    {
        StorageMNG storage = GetComponentInParent<StorageMNG>();
        
        Debug.Log(storage);
          
        if (!deployed)
        {
            storage.TintIcon(this);
        }
        else 
        {
            storage.RemoveHeroUsingObserver(charAttributes);
           // storage.ReturnRegiment(this);
        }


    }

    public void HeroIsDeployed()
    {
        backGround.sprite = storage.deployedRegiment;
        deployed = true;
    }

    public void ReturnDefaultState(CharAttributes selectedCharAttributes)
    {
        if (selectedCharAttributes == charAttributes)
        {
            backGround.sprite = GetComponentInParent<StorageMNG>().defaultIcon;

            deployed = false;
        }
    }


}
