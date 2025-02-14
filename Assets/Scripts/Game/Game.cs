using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Game {

    private TerrainType[,] terrainMap;
    private Building[,] buildingsMap;
    private Unit[,] unitsMap;

    private PlayerController PC;

    public Game(Vector2Int mapSize,int playersCount,int seed) {

        terrainMap = new TerrainType[mapSize.x, mapSize.y];
        buildingsMap = new Building[mapSize.x, mapSize.y];
        unitsMap = new Unit[mapSize.x, mapSize.y];
        PC = new PlayerController(playersCount);

        UnityEngine.Random.InitState(seed);
        WorldGen.GenerateWorld(terrainMap, buildingsMap,WorldGen.WorldType.defaultWorld);
        SetFreeSettlementsForPlayers();
    }

    /// <summary>
    /// Finds added villages and distributes them among players, one by one
    /// </summary>
    private void SetFreeSettlementsForPlayers()
    {
        List<Village> findVillages() {

            List<Village> villages = new List<Village>();

            for (int x = 0; x < buildingsMap.GetLength(0); x++)
            {
                for (int y = 0; y < buildingsMap.GetLength(1); y++)
                {
                    if (buildingsMap[x,y] is Village)
                        villages.Add((Village)buildingsMap[x, y]);
                }
            }
            return villages;
        }

        List<Village> villages = findVillages();

        PC.DistributeVillages(villages);
    }

    internal Building[,] GetBuildings()
    {
        return buildingsMap;
    }

    internal TerrainType[,] GetTerrain()
    {
        return terrainMap;
    }

    internal Unit[,] GetUnits()
    {
        return unitsMap;
    }

    public enum TerrainType
    {
        ground,
        mountain
    }
}
