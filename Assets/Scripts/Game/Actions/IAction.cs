using UnityEngine;
using static Render;

/// <summary>
/// Interface for actions that can be performed on the map.
/// </summary>
public interface IAction
{
    public delegate Vector3 LocalPosToGlobal(Vector2Int pos);
    public void Run(Map map, LocalPosToGlobal locPosToGlobal_del);
}
