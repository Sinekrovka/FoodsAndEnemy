using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel
{
    private bool _walkable;

    public bool Walkable
    {
        get => _walkable;
        set => _walkable = value;
    }
}
