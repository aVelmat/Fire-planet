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
    public GameObject cityPrefab;
    public GameObject riflemanPrefab;
    [Header("Selection Sprites")]
    public GameObject selectUnitSprite;
    public GameObject selectTileSprite;

    [SerializeField]
    private Vector2 mapScale;

    private readonly Vector3 TILES_OFFSET = new Vector3(0.5f,0, 0.5f);

    private GameObject[,] terrainMap;
    private GameObject[,] buildingsMap;
    private GameObject[,] unitsMap;

    public void InitWorld(Game.TerrainType[,] terrainMap, Building[,] buildings, Unit[,] units) {

        BuildTerrain(terrainMap);
        BuildBuildings(buildings);
        BuildUnits(units);
    }

    private void BuildTerrain(Game.TerrainType[,] terrainMap) {

        this.terrainMap = new GameObject[terrainMap.GetLength(0),terrainMap.GetLength(1)];

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
                        this.terrainMap[x,y] = Instantiate(mountainPrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void BuildBuildings(Building[,] buildingsMap)
    {
        this.buildingsMap = new GameObject[buildingsMap.GetLength(0),buildingsMap.GetLength(1)];

        for (int x = 0; x < buildingsMap.GetLength(0); x++)
        {
            for (int y = 0; y < buildingsMap.GetLength(1); y++)
            {
                Building building = buildingsMap[x, y];
                if (building is Village)
                {
                    this.buildingsMap[x, y] = Instantiate(villagePrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity);
                }

                if(building is City)
                {
                    this.buildingsMap[x, y] = Instantiate(cityPrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity);
                }
            }
        }
    }

    private void BuildUnits(Unit[,] units)
    {
        this.unitsMap = new GameObject[units.GetLength(0), units.GetLength(1)];
        for (int x = 0; x < units.GetLength(0); x++)
        {
            for (int y = 0; y < units.GetLength(1); y++)
            {
                Unit unit = units[x, y];
                if(unit is Rifleman)
                {
                    this.unitsMap[x, y] = Instantiate(riflemanPrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity);
                }
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

    internal void ClearSelection()
    {
        selectUnitSprite.SetActive(false);
        selectTileSprite.SetActive(false);
    }

    internal void ShowUnitSelection(Vector2Int vector2Int, float selectSpriteYoffset)
    {
        selectUnitSprite.SetActive(true);
        selectUnitSprite.transform.position = new Vector3(vector2Int.x * mapScale.x + TILES_OFFSET.x, selectSpriteYoffset + 0.505f, vector2Int.y * mapScale.y + TILES_OFFSET.z);
    }

    internal void ShowTileSelection(Vector2Int vector2Int, float selectSpriteYoffset)
    {
        selectTileSprite.SetActive(true);
        selectTileSprite.transform.position = new Vector3(vector2Int.x * mapScale.x + TILES_OFFSET.x, selectSpriteYoffset + 0.505f, vector2Int.y * mapScale.y + TILES_OFFSET.z);
    }
}
