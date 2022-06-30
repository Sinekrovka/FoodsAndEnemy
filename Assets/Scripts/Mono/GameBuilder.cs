using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    private LevelDescriptor _levelDescriptor;
    private void Awake()
    {
        LevelGenerator levelGenerator = new LevelGenerator();
        levelGenerator.Init();
        _levelDescriptor = levelGenerator.LevelDescriptor;
        BuildMap();
        CreateControllers();
    }

    private void BuildMap()
    {
        int rows = _levelDescriptor.Rows;
        int cols = _levelDescriptor.Cols;
        GameObject container = new GameObject("Map");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Vector3 position = new Vector3(-2.8f+j*0.5f, 4.8f-i * 0.5f);
                GameObject tile = Resources.Load<GameObject>(_levelDescriptor.IndexesTileStructure[i][j].PathPrefab);
                GameObject tileOnMap = Instantiate(tile, position, Quaternion.identity, container.transform);
                if (_levelDescriptor.IndexesTileStructure[i][j].Rotation)
                {
                    tileOnMap.transform.rotation = Quaternion.Euler(new Vector3(0,0, Random.Range(0,4)*90));
                }

                tileOnMap.AddComponent<TileController>();
            }
        }
    }

    private void CreateControllers()
    {
        
    }
}
