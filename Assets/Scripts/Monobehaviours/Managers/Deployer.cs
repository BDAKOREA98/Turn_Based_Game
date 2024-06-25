using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deployer : MonoBehaviour
{
    public static CharIcon readyForDeploymentIcon;
    List<BattleHex> enemiesPositions = new List<BattleHex>();
    List<CharAttributes> enemiesToDeploy = new List<CharAttributes>();
    static StorageMNG storage;
    int enemiesNum;

    void Start()
    {
        ActivatePositionsForRegiments();
        storage = FindObjectOfType<StorageMNG>();
        enemiesToDeploy = storage.currentProgress.enemies;
        enemiesNum = enemiesToDeploy.Count();
        PlaceEnemies();
    }
 
    public static void DeployRegiment(BattleHex parentObject)
    {
        Hero regiment = readyForDeploymentIcon.charAttributes.heroSO;
        Hero fighter = Instantiate(regiment, parentObject.Landscape.transform);
        
        parentObject.CleanUpDeploymentPosition();
        readyForDeploymentIcon.HeroIsDeployed();
        readyForDeploymentIcon = null;
        storage.GetComponent<StartBTN>().ControlStartBTN();
    }
    void ActivatePositionsForRegiments() 
    {
        foreach (BattleHex hex in FieldManager.allHexesArray)
        {
            if (hex.deploymentPos.regimentPosition == PositionForRegiment.player)
                                               
            {
                hex.MakeMeDeploymentPosition();
            }
        }
    }
    internal List<BattleHex> GetEnemiesPos()
    {
        enemiesPositions.Clear();
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.deploymentPos.regimentPosition == PositionForRegiment.enemy)
            {
                enemiesPositions.Add(hex);
            }
        }
        return enemiesPositions;
    }

    private void PlaceEnemies()
    {
        List<BattleHex> enemiesPositions = GetEnemiesPos();
        for (int i = 0; i < enemiesNum; i++)
        {       
            int positionsNum = enemiesPositions.Count();
            int randomIndex = UnityEngine.Random.Range(0, positionsNum - 1);
            
            Image landscape = enemiesPositions[randomIndex].Landscape;
            InstantiateEnemy(enemiesToDeploy[i], landscape);
            
            enemiesPositions.RemoveAt(randomIndex);
        }
    }
    private void InstantiateEnemy(CharAttributes charAttributes, Image hexPosition)
    {
        Hero enemy = Instantiate(charAttributes.heroSO, hexPosition.transform);
        enemy.gameObject.AddComponent<Enemy>();

        enemy.gameObject.AddComponent<AllPosForGroundAI>();

    }
}
