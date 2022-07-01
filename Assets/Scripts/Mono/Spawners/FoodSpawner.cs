using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private const int timeSpawn = 5;
    private List<GameObject> _foodObjects;
    private GameObject _foodContainer;
    private GameBuilder _gameBuilder;
    public void Init(List<FoodDescriptor> descriptors, GameBuilder builder)
    {
        _gameBuilder = builder;
        _foodContainer = new GameObject("FoodContainer");
        _foodObjects = new List<GameObject>();
        foreach (var foodDescriptor in descriptors)
        {
            GameObject foodItem = Resources.Load<GameObject>(foodDescriptor.PathPrefab);
            FoodModel foodModel = new FoodModel();
            foodModel.AddedHp = foodDescriptor.AddedHp;
            foodModel.LivedTime = foodDescriptor.LivingTime;
            foodItem.AddComponent<FoodController>().Init(foodModel);
            _foodObjects.Add(foodItem);
        }
    }

    private void Awake()
    {
        TimeSpawner();
    }

    private async void TimeSpawner()
    {
        await Task.Delay(timeSpawn * 1000);
        Instantiate(_foodObjects[Random.Range(0, _foodObjects.Count)], _gameBuilder.GetRandomWalkablePoint(),
            Quaternion.identity, _foodContainer.transform);
        TimeSpawner();
    }
}
