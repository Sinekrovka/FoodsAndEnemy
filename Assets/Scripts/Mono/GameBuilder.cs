using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    private LevelDescriptor _levelDescriptor;
    private List<Vector3> _walkableCoordinates;
    private void Awake()
    {
        LevelGenerator levelGenerator = new LevelGenerator();
        levelGenerator.Init();
        _levelDescriptor = levelGenerator.LevelDescriptor;
        BuildMap();
        CreateControllers();
        CreateSpawners();
    }

    private void BuildMap()
    {
        _walkableCoordinates = new List<Vector3>();
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
                TileModel tileModel = new TileModel();
                tileModel.Walkable = _levelDescriptor.IndexesTileStructure[i][j].Type;
                tileOnMap.AddComponent<TileController>();
                if (tileModel.Walkable)
                {
                    _walkableCoordinates.Add(tileOnMap.transform.position);
                }
                TileController controller = tileOnMap.GetComponent<TileController>();
                controller.Model = tileModel;
            }
        }
    }

    private void CreateControllers()
    {
        GameObject container = new GameObject("Controllers");
        GameObject inputController = Instantiate(new GameObject("InputController"), container.transform);
        inputController.AddComponent<InputController>().Init();
        GameObject playerMovement = Instantiate(new GameObject("PlayerMovementController"), container.transform);
        playerMovement.AddComponent<PlayerMovement>().Init(inputController.GetComponent<InputController>());
        GameObject gameController = Instantiate(new GameObject("Game Controller"), container.transform);
        GameController gameControllerScript = gameController.AddComponent<GameController>();
        gameControllerScript.TimeGame = _levelDescriptor.LevelTime;
    }

    private void CreateSpawners()
    {
        GameObject container = new GameObject("Spawners");
        GameObject foodSpawner = Instantiate(new GameObject("FoodSpawner"), container.transform);
        foodSpawner.AddComponent<FoodSpawner>().Init(_levelDescriptor.FoodDescriptors, this);
        GameObject enemySpawner = Instantiate(new GameObject("EnemySpawner"), container.transform);
        enemySpawner.AddComponent<EnemySpawner>().Init(_levelDescriptor.EnemiesDescriptors, this);
    }

    public Vector3 GetRandomWalkablePoint()
    {
        return _walkableCoordinates[Random.Range(0, _walkableCoordinates.Count)];
    }
}
