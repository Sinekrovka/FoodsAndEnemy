using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private FoodModel _foodModel;

    public FoodModel FoodModel
    {
        get => _foodModel;
        set => _foodModel = value;
    }
}
