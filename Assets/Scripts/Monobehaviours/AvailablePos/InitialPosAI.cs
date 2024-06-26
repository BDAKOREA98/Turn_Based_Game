using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPosAI : MonoBehaviour, IInitialHexes
{
    List<BattleHex> initialHexes = new List<BattleHex>();
    public List<BattleHex> GetNewInitialHexes()
    {
        initialHexes.Clear();
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.isNeighboringHex & !hex.isIncluded &&
                IfThereIsPlayersRegiment(hex))
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }

    private bool IfThereIsPlayersRegiment(BattleHex evaluatedHex)
    {
        bool AIPosfalse = true;
        if(evaluatedHex.GetComponentInChildren<Hero>() != null &&
            evaluatedHex.GetComponentInChildren<Enemy>() == null)
        {
            evaluatedHex.DefineMeAsPotencialTarget();
            AIPosfalse = false;
        }

        return AIPosfalse;


    }

}
