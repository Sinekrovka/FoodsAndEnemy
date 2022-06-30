using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private TileModel _model;

    public bool Walkable()
    {
        return _model.Walkable;
    }
}
