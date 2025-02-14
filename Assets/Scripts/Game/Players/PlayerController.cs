using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private List<Player> player;
    public PlayerController(int playersCount)
    {
        if(playersCount > GameConfig.MAX_PLAYERS)
            throw new System.ArgumentException("playersCount", "playersCount can't be greater than " + GameConfig.MAX_PLAYERS);

        PlayersCount = playersCount;

        player = new List<Player>();
        for (int i = 0; i < playersCount; i++)
        {
            player.Add(new Player(((Player.TeamColor)i));
        }
    }

    public void DistributeVillages(List<Village> villages) {

        // Shuffle the villages
        for (int i = villages.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (villages[i], villages[j]) = (villages[j], villages[i]); 
        }

        foreach (Player player in player)
        {
            player.Villages = new List<Village>();
        }
    }

    public int PlayersCount { get; }
}
