using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private List<Player> players;
    private int currTurn = 0;

    public PlayerController(int playersCount)
    {
        if(playersCount > GameConfig.MAX_PLAYERS)
            throw new System.ArgumentException($"playersCount can't be greater than {GameConfig.MAX_PLAYERS}");

        PlayersCount = playersCount;

        players = new List<Player>();
        for (int i = 0; i < playersCount; i++)
        {
            players.Add(new Player(((Player.TeamColor)i)));
        }
    }

    public void DistributeVillages(List<Village> villages) {

        if(villages.Count < players.Count)
            throw new System.ArgumentException($"Can't distribute villages! Villages count can't be less than players count. villages -> {villages.Count}. players -> {players.Count}");

        // Shuffle the villages
        for (int i = villages.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (villages[i], villages[j]) = (villages[j], villages[i]); 
        }

        for (int i = 0; i < players.Count;i++)
        {
            players[i].CaptureSettlement(villages[i]);
        }
    }

    public int PlayersCount { get; }
}
