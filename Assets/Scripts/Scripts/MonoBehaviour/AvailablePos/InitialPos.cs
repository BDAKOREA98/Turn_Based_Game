using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPos : IInitialHexes
{
    List<BattleHex> initialHexes = new List<BattleHex> ();

    public List<BattleHex> GetNewInitialHexes()//collects objects whose neighbours need to be found
    {
        initialHexes.Clear();// empty the array before filling it again
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.isNeighboringHex & !hex.isIncluded)//eliminates unnecessary hexes
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}
