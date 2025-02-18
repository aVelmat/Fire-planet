using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Game
{

    private Map<TerrainType> terrainMap;
    private Map<Building> buildingsMap;
    private Map<Unit> unitsMap;

    private PlayerController PC;

    public Game(Vector2Int mapSize, int playersCount, int seed)
    {

        UnityEngine.Random.InitState(seed);

        terrainMap = new Map<TerrainType>(mapSize);
        buildingsMap = new Map<Building>(mapSize);
        unitsMap = new Map<Unit>(mapSize);

        PC = new PlayerController(playersCount, CaputeSettlement, SpawnUnit);

        WorldGen.GenerateWorld(terrainMap, buildingsMap, WorldGen.WorldType.defaultWorld);
        SetStartSettlementsForPlayers();
        PC.DistributeStartUnits();
    }

    /// <summary>
    /// Finds added villages and distributes them among players, one by one
    /// </summary>
    private void SetStartSettlementsForPlayers()
    {
        List<Village> findVillages()
        {
            List<Village> villages = new List<Village>();

            for (int x = 0; x < buildingsMap.GetSize().x; x++)
            {
                for (int y = 0; y < buildingsMap.GetSize().y; y++)
                {
                    if (buildingsMap.Get(new Vector2Int(x, y)) is Village)
                        villages.Add((Village)buildingsMap.Get(new Vector2Int(x, y)));
                }
            }
            return villages;
        }

        List<Village> villages = findVillages();

        PC.DistributeVillages(villages);
    }

    public void CaputeSettlement(Player player, Vector2Int pos)
    {
        if (buildingsMap.Get(pos) is Village)
        {
            City city = new City(pos);
            city.SetOwner(player);
            buildingsMap.Set(pos, city);
        }
        else
        {
            City city = (City)buildingsMap.Get(pos);
            city.SetOwner(player);
        }
    }

    public void SpawnUnit(Unit unit)
    {
        unitsMap.Set(unit.GetPosition(), unit);
    }

    private void isValidUnitSpawn(Unit unit)
    {
        if (unitsMap.Get(unit.GetPosition()) != null || buildingsMap.Get(unit.GetPosition()) != null)
        {
            // Add your logic here
        }
    }

    #region Getters

    internal Map<Building> GetBuildings()
    {
        return buildingsMap;
    }

    internal Map<TerrainType> GetTerrain()
    {
        return terrainMap;
    }

    internal Map<Unit> GetUnits()
    {
        return unitsMap;
    }
    internal List<Vector2Int> GetUnitPossibleMovePoints(Vector2Int pos)
    {
        List <Vector2Int> possibleMoves = new List<Vector2Int>();
        for (int x = -1;x <= 1;x++)
            for(int y = -1;y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                Vector2Int newPos = pos + new Vector2Int(x, y);

                if (!isPosValid(newPos))
                    continue;

                if (unitsMap.Get(newPos) != null)
                    continue;

                possibleMoves.Add(newPos);
            }
        return possibleMoves;
    }

    internal Unit GetUnit(Vector2Int pos)
    {
        return unitsMap.Get(pos);
    }

    internal TerrainType GetTerrainElem(Vector2Int pos)
    {
        return terrainMap.Get(pos);
    }

    #endregion

    private bool isPosValid(Vector2Int pos) {
        return !(pos.x < 0 || pos.x >= unitsMap.GetSize().x || pos.y < 0 || pos.y >= unitsMap.GetSize().y);
    }

    public enum TerrainType
    {
        ground,
        mountain
    }
}
