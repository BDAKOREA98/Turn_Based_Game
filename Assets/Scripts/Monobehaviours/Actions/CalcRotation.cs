using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcRotation : MonoBehaviour
{
    static float direction;
    static float ZCoordinate;

    public static Quaternion CalculateRotation(Hero targetToAtack)
    {
        Vector3 targetPosition = targetToAtack.transform.position;
        Hero currentAttacker = BattleController.currentAttacker;
        Vector3 atackerPosition = currentAttacker.transform.position;
        ZCoordinate = GetAngle(targetPosition, atackerPosition);
        Quaternion rotation = Quaternion.EulerAngles(0, 0, ZCoordinate);
        return rotation;
    }
    private static float GetAngle(Vector3 targetPosition, Vector3 attackerPosition)
    {
      
        direction = Mathf.Atan((targetPosition.y - attackerPosition.y) /
                               (targetPosition.x - attackerPosition.x));

        if (targetPosition.x > attackerPosition.x)
        {
            ZCoordinate = direction;
        }
        else
        {
            ZCoordinate = Mathf.PI + direction;
        }
        return ZCoordinate;
    }
}
