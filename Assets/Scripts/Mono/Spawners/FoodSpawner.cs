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
        FoodModel foodModel = new FoodModel();
        foodModel.AddedHp = descriptor.AddedHp;
        foodModel.LivedTime = descriptor.LivingTime;
        foodItem.AddComponent<FoodController>();
        FoodController foodController = foodItem.GetComponent<FoodController>();
        foodController.FoodModel = foodModel;
        GameObject food = Instantiate(foodItem, _foodContainer.transform);
        Destroy(food, food.GetComponent<FoodController>().FoodModel.LivedTime);
        TimeSpawner();
    }
}
