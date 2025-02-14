using System.Collections.Generic;
using UnityEngine;

public class GameConfig
{
    public const int MAX_PLAYERS = 4;
    public const int VILLAGE_MIN_DIST = 5;

    public static readonly Dictionary<WorldGen.WorldType,float> MOUNTIANS_SPAWN_RARES = new Dictionary<WorldGen.WorldType, float> {
        {WorldGen.WorldType.defaultWorld, 0.1f}
    };

    
}
