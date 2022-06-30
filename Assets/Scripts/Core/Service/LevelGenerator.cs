using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private LevelDescriptor _levelDescriptor;

    private string PATH_CONFIG = "/Resources/Descriptors/";
    public void Init()
    {
        PATH_CONFIG = Application.dataPath + PATH_CONFIG;
        InitializationDescriptors();
    }

    private void InitializationDescriptors()
    {
        _levelDescriptor = new LevelDescriptor();
        _levelDescriptor.Init(PATH_CONFIG);
    }

    public LevelDescriptor LevelDescriptor => _levelDescriptor;
}
