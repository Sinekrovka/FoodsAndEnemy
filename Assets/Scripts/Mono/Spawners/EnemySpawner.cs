
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const int timeSpawn = 7;
    private List<GameObject> _enemiesList;
    private GameBuilder _gameBuilder;
    private GameObject _enemmyContainer;
    public void Init(List<EnemiesDescriptor> enemiesDescriptor, GameBuilder builder)
    {
        _enemmyContainer = new GameObject("Enemies");
        _gameBuilder = builder;
        _enemiesList = new List<GameObject>();
        foreach (var enemy in enemiesDescriptor)
        {
            EnemyModel model = new EnemyModel();
            model.Speed = enemy.Speed;
            model.Damage = enemy.Damage;
            model.HP = enemy.Hp;
            GameObject enemyItem = Resources.Load<GameObject>(enemy.PrefabPath);
            EnemyController enemyController = enemyItem.AddComponent<EnemyController>();
            enemyController.EnemyModel = model;
            enemyController.Init(_gameBuilder);
        }
    }

    private void Awake()
    {
        TimeSpawner();
    }

    private async void TimeSpawner()
    {
        await Task.Delay(timeSpawn * 1000);
        Instantiate(_enemiesList[Random.Range(0, _enemiesList.Count)], _gameBuilder.GetRandomWalkablePoint(),
            Quaternion.identity, _enemmyContainer.transform);
        TimeSpawner();
    }
}
