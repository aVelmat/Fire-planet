using UnityEngine;

public class MoveUnit : IAction
{
    private Vector2Int unitPos,unitNewPos;
    private bool isDeactivate;
    public MoveUnit(Vector2Int unitPos, Vector2Int unitNewPos, bool isDeactivate)
    {
        this.unitPos = unitPos;
        this.unitNewPos = unitNewPos;
        this.isDeactivate = isDeactivate;
    }

    public void Run(Render.Map map, IAction.LocalPosToGlobal locPosToGlobal_del)
    {
        map.unitsMap.Get(unitPos).transform.position = locPosToGlobal_del(unitNewPos);
        map.unitsMap.Move(unitPos, unitNewPos);

        if(isDeactivate)
            map.unitsMap.Get(unitNewPos).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
