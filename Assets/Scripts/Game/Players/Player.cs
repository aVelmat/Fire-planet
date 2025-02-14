using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private List<Settlement> settlements = new List<Settlement>();

    public TeamColor Team { get; private set; }

    public Player(TeamColor team)
    {
        Team = team;
    }

    public void CaptureSettlement(Settlement settlement)
    {
        settlement.SetOwner(this);
        settlements.Add(settlement);
    }

    public enum TeamColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }
}
