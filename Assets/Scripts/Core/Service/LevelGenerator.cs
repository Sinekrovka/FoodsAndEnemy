using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private FoodDescriptor _foodDescriptor;
    private EnemiesDescriptor _enemiesDescriptor;
    private LevelDescriptor _levelDescriptor;
    public void Init()
    {
        InitializationDescriptors();
    }

    private void InitializationDescriptors()
    {
        _foodDescriptor = new FoodDescriptor();
        _enemiesDescriptor = new EnemiesDescriptor();
        _levelDescriptor = new LevelDescriptor();
        _foodDescriptor.Init();
        _enemiesDescriptor.Init();
        _levelDescriptor.Init();
    }
}
