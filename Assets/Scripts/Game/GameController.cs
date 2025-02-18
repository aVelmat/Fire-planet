using NUnit.Framework;
using System.Collections.Generic;
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
        render = GetComponent<Render>();
        SelTool = new SelectionTool(render);

        render.InitWorld(game.GetTerrain(), game.GetBuildings(), game.GetUnits());

        Vector2 mapScale = render.GetMapScale();
        CC.SetMoveLimits(new Vector3(-5, 0, -5), new Vector3(mapSize.x * mapScale.x, GameConfig.CAMERA_MAX_Y, mapSize.y * mapScale.y));
        CC.TileClicked += OnTileClicked;

        //render.SetWorldState(game.GetBuildings(), game.GetUnits());
    }

    public void OnTileClicked(Vector2Int pos)
    {

        if (SelTool.selectionType == SelectionTool.SelectionType.Unit && pos == SelTool.selectedTilePosition)
        {
            List<Vector2Int> possibleMovePoints = game.GetUnitPossibleMovePoints(pos);
            if (possibleMovePoints != null && MathUtils.IsListContainsVec2Int(possibleMovePoints, pos))
            {
                //Move unit
            }
            else
            {
                SelectTile(pos);
            }
        }
        else
        {
            if (game.GetUnit(pos) != null)
            {
                if (SelTool.selectionType == SelectionTool.SelectionType.Tile && SelTool.selectedTilePosition == pos)
                    SelTool.ClearSelection();
                else
                    SelectUnit(pos, game.GetUnitPossibleMovePoints(pos));
            }
            else
            {
                if (SelTool.selectedTilePosition != pos)
                {
                    SelectTile(pos);
                }
                else
                {
                    SelTool.ClearSelection();
                }
            }
        }
    }

    private void SelectTile(Vector2Int pos)
    {
        float yOffset = 0;
        if (game.GetTerrainElem(pos) == Game.TerrainType.mountain)
            yOffset = 0.12f;
        SelTool.SelectTile(pos, yOffset);
    }

    private void SelectUnit(Vector2Int pos,List<Vector2Int> movePoints)
    {
        float yOffset = 0;
        if (game.GetTerrainElem(pos) == Game.TerrainType.mountain)
            yOffset = 0.12f;
        SelTool.SelectUnit(pos, movePoints, yOffset);
    }
}
