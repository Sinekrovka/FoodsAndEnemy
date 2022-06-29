using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private LevelDescriptor _levelDescriptor;

    private const string PATH_CONFIG = "Descriptors/";
    public void Init()
    {
        Configure();
        InitializationDescriptors();
    }

    private void InitializationDescriptors()
    {
        _levelDescriptor = new LevelDescriptor();
        _levelDescriptor.Init(PATH_CONFIG);
    }

    private void Configure()
    {
        
    }
}
