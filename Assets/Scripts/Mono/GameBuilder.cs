using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    private LevelGenerator _levelGenerator;
    private void Awake()
    {
        _levelGenerator = new LevelGenerator();
        _levelGenerator.Init();
    }
}
