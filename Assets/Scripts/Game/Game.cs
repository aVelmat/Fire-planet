using UnityEngine;

public class Game : MonoBehaviour {

    private TerrainType[,] terrainMap;
    private Building[,] buildingsMap;
    private Unit[,] unitsMap;

    private Render render;

    public Game(Vector2Int mapSize) {

        terrainMap = new TerrainType[mapSize.x, mapSize.y];
        buildingsMap = new Building[mapSize.x, mapSize.y];
        unitsMap = new Unit[mapSize.x, mapSize.y];

        WorldGen.GenerateWorld(terrainMap, buildingsMap,WorldGen.WorldType.defaultWorld,1);
        render.SetWorldState(terrainMap,buildingsMap,unitsMap);

    }

    public enum TerrainType
    {
        ground,
        mountain
    }
}
