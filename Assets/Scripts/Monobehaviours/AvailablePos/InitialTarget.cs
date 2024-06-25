using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTarget : IInitialHexes
{
    List<BattleHex> initialHexes = new List<BattleHex>();
    public List<BattleHex> GetNewInitialHexes()
    {
        initialHexes.Clear();
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.lookingForTarget)
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}
