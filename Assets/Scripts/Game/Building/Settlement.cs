using System;
using UnityEngine;

public class Settlement : Building
{
    public Player Owner { get; private set; }
    public Settlement(Vector2Int newPos) : base(newPos)
    {
    }

    public void SetOwner(Player player)
    {
        Owner = player;
    }
}
