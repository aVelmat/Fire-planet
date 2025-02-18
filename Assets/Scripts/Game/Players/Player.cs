using NUnit.Framework;
using System;
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

    public City GetCity(int num) { return cities[num]; }
    public void AddCity(City city) { cities.Add(city); }

    internal int GetCitiesCount()
    {
        return cities.Count;
    }

    public enum TeamColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }
}
