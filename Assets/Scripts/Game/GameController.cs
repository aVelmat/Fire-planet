using UnityEngine;
using UnityEngine.TerrainUtils;

public class GameController : MonoBehaviour
{
    public CameraController CC;

    public Vector2Int mapSize;

    private Render render;
    private Game game;
    private SelectionTool SelTool;
    public void Start()
    {
        game = new Game(mapSize,2,1);
        SelTool = new SelectionTool(render);
        render = GetComponent<Render>();

        render.InitWorld(game.GetTerrain(), game.GetBuildings(), game.GetUnits());

        Vector2 mapScale = render.GetMapScale();
        CC.SetMoveLimits(new Vector3(-5, 0, -5), new Vector3(mapSize.x * mapScale.x, GameConfig.CAMERA_MAX_Y, mapSize.y * mapScale.y));
        CC.TileClicked += OnTileClicked;

        //render.SetWorldState(game.GetBuildings(), game.GetUnits());
    }

    public void OnTileClicked(Vector2Int pos)
    {

    }
}
