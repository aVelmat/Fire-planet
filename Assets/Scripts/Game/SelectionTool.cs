
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class is responsible for handling and rendering the selection of objects/unit moving points in the game. 
/// </summary>
public class SelectionTool
{
    public SelectionType selectionType { get; private set; } = SelectionType.None;
    public Vector2Int selectedTilePosition { get; private set; }
    private Render render;

    public SelectionTool(Render render)
    {
        this.render = render;
    }

    /// <summary>
    /// Selects a tile with unit and renders the selection.
    /// </summary>
    /// <param name="unit"></param>
    public void SelectUnit(Vector2Int pos,List<Vector2Int> movePoints, float selectSpriteYoffset) {

        render.ClearSelection();
        render.ShowUnitSelection(pos, selectSpriteYoffset);
        render.CreateUnitMovePoints(movePoints, selectSpriteYoffset);
        selectionType = SelectionType.Unit;
        this.selectedTilePosition = pos;
    }

    /// <summary>
    /// Selects a tile with building and renders the selection.
    /// </summary>
    /// <param name="unit"></param>
    public void SelectBuilding(Vector2Int pos, float selectSpriteYoffset)
    {
        render.ClearSelection();
        render.ShowTileSelection(pos, selectSpriteYoffset);
        selectionType = SelectionType.Tile;
        this.selectedTilePosition = pos;
    }

    /// <summary>
    /// Selects a terrain tile and renders the selection.
    /// </summary>
    /// <param name="unit"></param>
    public void SelectTile(Vector2Int pos,float selectSpriteYoffset)
    {
        render.ClearSelection();
        render.ShowTileSelection(pos, selectSpriteYoffset);
        selectionType = SelectionType.Tile;
        this.selectedTilePosition = pos;
    }

    public void ClearSelection()
    {
        render.ClearSelection();
        selectionType = SelectionType.None;
        selectedTilePosition = new Vector2Int(-1, -1);
    }


    public enum SelectionType
    {
        None,
        Tile,
        Unit
    }
}