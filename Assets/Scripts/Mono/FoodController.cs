using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private FoodModel _model;
    public void Init(FoodModel model)
    {
        _model = model;
    }

    private void Awake()
    {
        Destroy(gameObject, _model.LivedTime);
    }

    public FoodModel Model => _model;
}
