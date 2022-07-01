using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private const int timeSpawn = 5;
    private List<FoodDescriptor> _foodObjects;
    private GameObject _foodContainer;
    public void Init(List<FoodDescriptor> descriptors)
    {
        _foodContainer = new GameObject("FoodContainer");
        _foodObjects = descriptors;
    }

    private void Awake()
    {
        TimeSpawner();
    }

    private async void TimeSpawner()
    {
        await Task.Delay(timeSpawn * 1000);
        FoodDescriptor descriptor = _foodObjects[Random.Range(0, _foodObjects.Count)];
        GameObject foodItem = Resources.Load<GameObject>(descriptor.PathPrefab);
        GameObject food = Instantiate(foodItem, GameBuilder.Instance.GetRandomWalkablePoint(), Quaternion.identity, _foodContainer.transform);
        FoodController foodController = food.GetComponent<FoodController>();
        foodController.Food_Model = new FoodModel();
        foodController.Food_Model.AddedHp = descriptor.AddedHp;
        foodController.Food_Model.LivedTime = descriptor.LivingTime;
        Destroy(food, foodController.Food_Model.LivedTime);
        TimeSpawner();
    }
}
