using UnityEngine;

public class Map<T>
{
    private T[,] map;

    public Map(Vector2Int size)
    {
        map = new T[size.x, size.y];
    }

    public void Set(int x, int y, T value)
    {
        map[x, y] = value;
    }

    public void Set(Vector2Int pos, T value)
    {
        map[pos.x, pos.y] = value;
    }

    public T Get(Vector2Int pos)
    {
        return map[pos.x, pos.y];
    }

    public T Get(int x,int y)
    {
        return map[x, y];
    }

    public Vector2Int GetSize()
    {
        return new Vector2Int(map.GetLength(0), map.GetLength(1));
    }

    public int GetSize(int n)
    {
        return map.GetLength(n);
    }
}
