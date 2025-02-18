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
    [Header("Dynamic GUI Sprites")]
    public GameObject selectUnitSprite;
    public GameObject selectTileSprite;
    public GameObject unitMovePointSprite;

    [SerializeField]
    private Vector2 mapScale;

    private readonly Vector3 TILES_OFFSET = new Vector3(0.5f, 0, 0.5f);

    private Map map;

    private List<GameObject> unitMovePoints = new List<GameObject>();

    public void InitWorld(Map<Game.TerrainType> terrainMap, Map<Building>  buildings, Map<Unit> units)
    {
        BuildTerrain(terrainMap);
        BuildBuildings(buildings);
        BuildUnits(units);
    }

    private void BuildTerrain(Map<Game.TerrainType> terrainMap)
    {
        map.terrainMap = new Map<GameObject>(new Vector2Int(terrainMap.GetSize(0), terrainMap.GetSize(1)));

        GameObject ground = Instantiate(groundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ground.transform.position = new Vector3(terrainMap.GetSize(0) * mapScale.x / 2, 0, terrainMap.GetSize(1) * mapScale.y / 2);
        ground.transform.localScale = new Vector3(terrainMap.GetSize(0) * mapScale.x, 1, terrainMap.GetSize(1) * mapScale.y);

        for (int x = 0; x < terrainMap.GetSize(0); x++)
        {
            for (int y = 0; y < terrainMap.GetSize(1); y++)
            {
                switch (terrainMap.Get(x,y))
                {
                    case Game.TerrainType.mountain:
                        map.terrainMap.Set(x, y, Instantiate(mountainPrefab, LocalPosToGlobal(x, y), Quaternion.identity));
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void BuildBuildings(Map<Building> buildingsMap)
    {
        map.buildingsMap = new Map<GameObject>(new Vector2Int(buildingsMap.GetSize(0), buildingsMap.GetSize(1)));

        for (int x = 0; x < buildingsMap.GetSize(0); x++)
        {
            for (int y = 0; y < buildingsMap.GetSize(1); y++)
            {
                Building building = buildingsMap.Get(x,y);
                if (building is Village)
                {
                    map.buildingsMap.Set(x, y, Instantiate(villagePrefab, LocalPosToGlobal(x, y), Quaternion.identity));
                }

                if (building is City)
                {
                    map.buildingsMap.Set(x, y, Instantiate(cityPrefab, LocalPosToGlobal(x, y), Quaternion.identity));
                }
            }
        }
    }

    private void BuildUnits(Map<Unit> units)
    {
        map.unitsMap = new Map<GameObject>(new Vector2Int(units.GetSize(0), units.GetSize(1)));
        for (int x = 0; x < units.GetSize(0); x++)
        {
            for (int y = 0; y < units.GetSize(1); y++)
            {
                Unit unit = units.Get(x, y);
                if (unit is Rifleman)
                {
                    map.unitsMap.Set(x, y, Instantiate(riflemanPrefab, LocalPosToGlobal(x,y), Quaternion.identity));
                }
            }
        }
    }

    private Vector3 LocalPosToGlobal(Vector2Int pos) {

        return new Vector3(pos.x * mapScale.x + TILES_OFFSET.x, 0, pos.y * mapScale.y + TILES_OFFSET.z);
    }

    private Vector3 LocalPosToGlobal(int x,int y)
    {
        return new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z);
    }

    internal void SetWorldState(Building[,] buildingsMap, Unit[,] unitsMap)
    {
        throw new NotImplementedException();
    }

    public void RunAction(IAction action)
    {
        action.Run(map, LocalPosToGlobal);
    }

    public Vector2 GetMapScale()
    {
        return mapScale;
    }

    #region Selection_And_Movement

    public void ClearSelection()
    {
        ClearUnitMovePos();
        selectUnitSprite.SetActive(false);
        selectTileSprite.SetActive(false);
    }

    private void ClearUnitMovePos()
    {
        foreach (GameObject movePoint in unitMovePoints)
        {
            Destroy(movePoint);
        }
    }

    public void ShowUnitSelection(Vector2Int vector2Int, float selectSpriteYoffset)
    {
        selectUnitSprite.SetActive(true);
        selectUnitSprite.transform.position = new Vector3(vector2Int.x * mapScale.x + TILES_OFFSET.x, selectSpriteYoffset + 0.505f, vector2Int.y * mapScale.y + TILES_OFFSET.z);
    }

    public void ShowTileSelection(Vector2Int vector2Int, float selectSpriteYoffset)
    {
        selectTileSprite.SetActive(true);
        selectTileSprite.transform.position = new Vector3(
            vector2Int.x * mapScale.x + TILES_OFFSET.x, 
            selectSpriteYoffset + 0.505f, 
            vector2Int.y * mapScale.y + TILES_OFFSET.z
        );
    }

    public void CreateUnitMovePoints(List<Vector2Int> movePoints,float moveSpriteYOffset)
    {
        ClearUnitMovePos();

        if (movePoints == null)
            return;

        foreach (Vector2Int movePoint in movePoints)
        {
            GameObject movePointObj = Instantiate(
                unitMovePointSprite, 
                new Vector3(
                    movePoint.x * mapScale.x + TILES_OFFSET.x,
                    moveSpriteYOffset + 0.505f, 
                    movePoint.y * mapScale.y + TILES_OFFSET.z), 
                Quaternion.identity);
            unitMovePoints.Add(movePointObj);
        }
    }

    #endregion

    public struct Map {

        public Map<GameObject> terrainMap;
        public Map<GameObject> buildingsMap;
        public Map<GameObject> unitsMap;

    }
}
