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

    private List<IAction> actions = new List<IAction>();
    public void Start()
    {
        game = new Game(mapSize,2,1);
        render = GetComponent<Render>();
        SelTool = new SelectionTool(render, IsUnitExsist, GetSelectSpriteYoffset);

        render.InitWorld(game.GetTerrain(), game.GetBuildings(), game.GetUnits());

        Vector2 mapScale = render.GetMapScale();
        CC.SetMoveLimits(new Vector3(-5, 0, -5), new Vector3(mapSize.x * mapScale.x, GameConfig.CAMERA_MAX_Y, mapSize.y * mapScale.y));
        CC.TileClicked += OnTileClicked;

        //render.SetWorldState(game.GetBuildings(), game.GetUnits());
    }

    public void OnTileClicked(Vector2Int pos)
    {
        if (pos != SelTool.selectedTilePosition)
        {
            if(SelTool.selectionType == SelectionTool.SelectionType.Unit && game.IsUnitActive(SelTool.selectedTilePosition)) {

                List<Vector2Int> movePoints = game.GetUnitPossibleMovePoints(SelTool.selectedTilePosition);
                if (movePoints != null && MathUtils.IsListContainsVec2Int(movePoints, pos))
                {
                    // Unit move
                    game.MoveUnit(SelTool.selectedTilePosition, pos);
                    AddAndRunAction(new MoveUnit(SelTool.selectedTilePosition, pos,true));

                    SelTool.ClearSelection();
                    return;
                }
            }

            SelTool.Select(pos);
        }
        else
        {
            SelTool.IncreaseSelectLevel();
        }
    }

    private void AddAndRunAction(IAction action) {

        actions.Add(action);
        render.RunAction(action);
    }

    private bool IsUnitExsist(Vector2Int pos,out List<Vector2Int> movePoints) {

        movePoints = null;

        if (game.GetUnit(pos) != null)
        {
            movePoints = game.GetUnitPossibleMovePoints(pos);

            return true;
        }
        return false;
    }

    private float GetSelectSpriteYoffset(Vector2Int pos)
    {
        if (game.GetTerrainElem(pos) == Game.TerrainType.mountain)
            return 0.12f;
        return 0;
    }
}
