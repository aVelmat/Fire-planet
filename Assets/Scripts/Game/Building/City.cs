using UnityEngine;

public class City : Building
{
    public Player Owner { get; private set; }
    public City(Vector2Int newPos) : base(newPos)
    {
    }

    public void SetOwner(Player player)
    {
        Owner = player;
        player.AddCity(this);
    }
}
