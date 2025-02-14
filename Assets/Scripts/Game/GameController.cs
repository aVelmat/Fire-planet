using UnityEngine;
using UnityEngine.TerrainUtils;

public class GameController : MonoBehaviour
{
    public Vector2Int mapSize;

    private Render render;
    private Game game;

    public void Start()
    {
        game = new Game(mapSize,2,1);

        render = GetComponent<Render>();
        render.InitWorld(game.GetTerrain(), game.GetBuildings(), game.GetUnits());
        //render.SetWorldState(game.GetBuildings(), game.GetUnits());
    }
}
