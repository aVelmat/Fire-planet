using System;
using UnityEngine;

public class Render : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject groundPrefab;
    public GameObject mountainPrefab;

    [SerializeField]
    private Vector2 mapScale;

    private readonly Vector3 TILES_OFFSET = new Vector3(0.5f,0, 0.5f);

    public void InitWorld(Game.TerrainType[,] terrainMap) {

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
                        Instantiate(mountainPrefab, new Vector3(x * mapScale.x + TILES_OFFSET.x, 0, y * mapScale.y + TILES_OFFSET.z), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }

    }
    internal void SetWorldState(Building[,] buildingsMap, Unit[,] unitsMap)
    {
        throw new NotImplementedException();
    }
}
