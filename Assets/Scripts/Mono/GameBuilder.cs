using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    public static GameBuilder Instance;
    private LevelDescriptor _levelDescriptor;
    private List<Vector3> _walkableCoordinates;
    private void Awake()
    {
        Instance = this;
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
        GameObject inputController = new GameObject("InputController");
        inputController.AddComponent<InputController>().Init();
        inputController.transform.SetParent(container.transform);
        GameObject playerMovement = new GameObject("PlayerMovementController");
        playerMovement.AddComponent<PlayerMovement>().Init(inputController.GetComponent<InputController>());
        playerMovement.transform.SetParent(container.transform);
        GameObject gameController = new GameObject("Game Controller");
        GameController gameControllerScript = gameController.AddComponent<GameController>();
        gameController.transform.SetParent(container.transform);
        gameControllerScript.TimeGame = _levelDescriptor.LevelTime;
    }

    private void CreateSpawners()
    {
        GameObject container = new GameObject("Spawners");
        GameObject foodSpawner = new GameObject("FoodSpawner");
        foodSpawner.transform.SetParent(container.transform);
        foodSpawner.AddComponent<FoodSpawner>().Init(_levelDescriptor.FoodDescriptors);
        GameObject enemySpawner = new GameObject("EnemySpawner");
        enemySpawner.transform.SetParent(container.transform);
        enemySpawner.AddComponent<EnemySpawner>().Init(_levelDescriptor.EnemiesDescriptors);
    }

    public Vector3 GetRandomWalkablePoint()
    {
        return _walkableCoordinates[Random.Range(0, _walkableCoordinates.Count)];
    }
}
