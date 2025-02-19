using UnityEngine;
using static Render;

public abstract class Action
{
    protected Render render;
    public Action(Render render)
    {
        this.render = render;
    }
    public abstract void Run(Map map);
}
