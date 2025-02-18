using System;
using UnityEngine;

public class Unit : GameObjectBase
{
    public Player Owner { get; private set; }
    public bool isCanMoveInTurn = true;
    public Unit(Vector2Int pos, Player owner) : base(pos)
    {
        Owner = owner;
    }

    public void OnMove()
    {
        isCanMoveInTurn = false;
    }
}
