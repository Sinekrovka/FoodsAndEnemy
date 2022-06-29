using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodModel
{
    private int _addedHP;
    private int _livedTime;

    public int AddedHp
    {
        get => _addedHP;
        set => _addedHP = value;
    }

    public int LivedTime
    {
        get => _livedTime;
        set => _livedTime = value;
    }
}
