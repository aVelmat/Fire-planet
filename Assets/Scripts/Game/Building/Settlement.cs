using System;
using UnityEngine;

public class Settlement : Building
{
    public Settlement(Vector2Int newPos) : base(newPos)
    {
    }

    public void SetOwner(Player player)
    {
        throw new NotImplementedException();
    }
}
