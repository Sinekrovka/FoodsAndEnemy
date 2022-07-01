using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const int timeSpawn = 7;
    private List<EnemiesDescriptor> _enemiesList;
    private GameObject _enemmyContainer;
    public void Init(List<EnemiesDescriptor> enemiesDescriptor)
    {
        _enemmyContainer = new GameObject("Enemies");
        _enemiesList = enemiesDescriptor;
    }

    private void Awake()
    {
        TimeSpawner();
    }

    private async void TimeSpawner()
    {
        await Task.Delay(timeSpawn * 1000);
        EnemiesDescriptor enemy = _enemiesList[Random.Range(0, _enemiesList.Count)];
        EnemyModel model = new EnemyModel();
        model.Speed = enemy.Speed;
        model.Damage = enemy.Damage;
        model.HP = enemy.Hp;
        GameObject enemyItem = Resources.Load<GameObject>(enemy.PrefabPath);
        EnemyController enemyController = enemyItem.AddComponent<EnemyController>();
        enemyController.EnemyModel = model;
        Instantiate(enemyItem, _enemmyContainer.transform);
        TimeSpawner();
    }
}
