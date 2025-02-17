using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private List<City> cities = new List<City>();

    public TeamColor Team { get; private set; }

    public Player(TeamColor team)
    {
        Team = team;
    }

    public enum TeamColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }
}
