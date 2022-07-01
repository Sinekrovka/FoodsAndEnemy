using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private FoodModel _foodModel;

    public FoodModel Food_Model
    {
        get => _foodModel;
        set => _foodModel = value;
    }
}
