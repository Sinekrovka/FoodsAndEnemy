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
        GameObject enemyItem = Resources.Load<GameObject>(enemy.PrefabPath);
        enemyItem = Instantiate(enemyItem, GameBuilder.Instance.GetRandomWalkablePoint(), Quaternion.identity, _enemmyContainer.transform);
        EnemyController enemyController = enemyItem.GetComponent<EnemyController>();
        enemyController.Enemy_Model = new EnemyModel();
        enemyController.Enemy_Model.HP = enemy.Hp;
        enemyController.Enemy_Model.Damage = enemy.Damage;
        enemyController.Enemy_Model.Speed = enemy.Speed;
        enemyController.Moved();
        TimeSpawner();
    }
}
