using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CurrentProgress", menuName = "CurrentProgres/Bar")]
public class CurrentProgress : ScriptableObject
{
    [SerializeField] internal List<CharAttributes> heroesOfPlayer;
    [SerializeField] internal List<CharAttributes> enemies;



    
}
