using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class Render : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject groundPrefab;
    public GameObject mountainPrefab;
    public GameObject villagePrefab;

    [SerializeField]
    private Vector2 mapScale;

    private readonly Vector3 TILES_OFFSET = new Vector3(0.5f,0, 0.5f);

    private List<GameObject> terrainTiles = new List<GameObject>();
    private List<GameObject> buildings = new List<GameObject>();

    public void InitWorld(Game.TerrainType[,] terrainMap, Building[,] buildings, Unit[,] units) {

        BuildTerrain(terrainMap);
        BuildBuildings(buildings);
        BuildUnits(units);
    }

    private void BuildTerrain(Game.TerrainType[,] terrainMap) {

        GameObject ground = Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ground.transform.position = new Vector3(terrainMap.GetLength(0) * mapScale.x / 2, 0, terrainMap.GetLength(1) * mapScale.y / 2);
        ground.transform.localScale = new Vector3(terrainMap.GetLength(0) * mapScale.x, 1, terrainMap.GetLength(1) * mapScale.y);

        for (int x = 0; x < terrainMap.GetLength(0); x++)
        {
            for (int y = 0; y < terrainMap.GetLength(1); y++)
            {
                switch (terrainMap[x, y])
                {
                    case Game.TerrainType.mountain:
                        terrainTiles.Add(Instantiate(mountainPrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity));
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void BuildBuildings(Building[,] buildingsMap)
    {
        for (int x = 0; x < buildingsMap.GetLength(0); x++)
        {
            for (int y = 0; y < buildingsMap.GetLength(1); y++)
            {
                Building building = buildingsMap[x, y];
                if (building is Village)
                {
                    buildings.Add(Instantiate(villagePrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity));
                }
            }
        }
    }

    private void BuildUnits(Unit[,] units)
    {
        for (int x = 0; x < units.GetLength(0); x++)
        {
            for (int y = 0; y < units.GetLength(1); y++)
            {
                Unit unit = units[x, y];
                //if (building is Village)
                //{
                //    Instantiate(villagePrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity);
                //}
            }
        }
    }

    internal void SetWorldState(Building[,] buildingsMap, Unit[,] unitsMap)
    {
        throw new NotImplementedException();
    }

    public Vector2 GetMapScale()
    {
        return mapScale;
    }
}
