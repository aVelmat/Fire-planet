using System.Collections.Generic;
using UnityEngine;

public class MathUtils
{
    public static bool IsListContainsVec2Int(List<Vector2Int> list, Vector2Int vector)
    {
        foreach (var item in list)
        {
            if (item.x == vector.x && item.y == vector.y)
            {
                return true;
            }
        }
        return false;
    }
}
