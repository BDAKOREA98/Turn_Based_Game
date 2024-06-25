using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPos : IInitialHexes
{
    List<BattleHex> initialHexes = new List<BattleHex>();
    public List<BattleHex> GetNewInitialHexes()
    {
        initialHexes.Clear();
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.isNeighboringHex & !hex.isIncluded)
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}
