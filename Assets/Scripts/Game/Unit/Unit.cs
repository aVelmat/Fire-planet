using UnityEngine;

public class Unit : GameObjectBase
{
    public bool isCanMoveInTurn = true;
    public Unit(Vector2Int pos) : base(pos)
    {
    }
}
