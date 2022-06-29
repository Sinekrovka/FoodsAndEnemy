using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel
{
    public enum TileType
    {
        Walkable,
        NoWalkable,
    }

    private TileType _type;

    public TileType Type
    {
        get => _type;
        set => _type = value;
    }
}
