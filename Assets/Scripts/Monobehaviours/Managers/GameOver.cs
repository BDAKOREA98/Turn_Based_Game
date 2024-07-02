using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public CurrentProgress currentProgress;
    public List<CharIcon> heroIcons;
    List<CharAttributes> regimentsSO = new List<CharAttributes>();
    ScrollRect scrollRect;
    [SerializeField] CharIcon iconPrefab;


    [SerializeField] internal TMPro.TextMeshProUGUI VicOrDefeat;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        CallHeroICons();
     
    }


    public void DefeatOrVictory(bool victory)        
    {
        if(victory)
        {
            VicOrDefeat.text = "Victory";

        }
        else
        {
            VicOrDefeat.text = "Defeat";
        }

    }


    public void CallHeroICons()
    {
        regimentsSO = currentProgress.heroesOfPlayer;
        Transform parentOfIcons = scrollRect.content.transform;
        for (int i = 0; i < regimentsSO.Count; i++)
        {
            if(regimentsSO[i].isDeployed)
            {
                CharIcon fighterIcon = Instantiate(iconPrefab, parentOfIcons);

                fighterIcon.FillIconWhenGameIsOver(regimentsSO[i]);
            }
        }

    }




}
