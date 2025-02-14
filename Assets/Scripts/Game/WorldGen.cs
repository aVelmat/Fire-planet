
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Game;

public class WorldGen
{
    internal static void GenerateWorld(TerrainType[,] terrainMap, Building[,] buildingsMap, WorldType worldType)
    {
        // Generate terrain tiles
        for (int x = 0; x < terrainMap.GetLength(0); x++)
        {
            for (int y = 0; y < terrainMap.GetLength(1); y++)
            {
                if(Random.Range(0f,1f) < GameConfig.MOUNTIANS_SPAWN_RARES[worldType])
                    terrainMap[x,y] = TerrainType.mountain;
                else
                    terrainMap[x, y] = TerrainType.ground;
            }
        }

        // Generate villages
        List<Village> villages = new List<Village>();

        int villagesCount = CalcVillagesCount(terrainMap.GetLength(0) * terrainMap.GetLength(1));

        for (int i = 0; i < villagesCount; i++)
        {
            for (int j = 0;j < 100;j++)
            {
                Vector2Int newPos = new Vector2Int(Random.Range(0, terrainMap.GetLength(0)), Random.Range(0, terrainMap.GetLength(1)));

                if(IsVillagePlaceable(terrainMap, villages, newPos))
                {
                    Village village = new Village(newPos);
                    villages.Add(village);
                    buildingsMap[newPos.x, newPos.y] = village;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Calculates the number of villages that can be placed on the map depending on the area
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    private static int CalcVillagesCount(float area)
    {
        return (int)(area / 32f);
    }

    private static bool IsVillagePlaceable(TerrainType[,] terrainMap,List<Village> villages, Vector2Int pos)
    {
        if (terrainMap[pos.x, pos.y] != TerrainType.ground)
            return false;

        foreach (Village village in villages)
        {
            if (Vector2Int.Distance(new Vector2Int(pos.x, pos.y), village.GetPosition()) < GameConfig.VILLAGE_MIN_DIST)
                return false;
        }

        return true;
    }

    public enum WorldType { 
        defaultWorld
    }
}
