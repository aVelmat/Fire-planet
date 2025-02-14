using UnityEngine;
using UnityEngine.TerrainUtils;

public class GameController : MonoBehaviour
{
    public Vector2Int mapSize;

    private Render render;

    public void Start()
    {
        Game game = new Game(mapSize,2,1);

        render = GetComponent<Render>();
        render.InitWorld(game.GetTerrain());
        //render.SetWorldState(game.GetBuildings(), game.GetUnits());
    }
}
