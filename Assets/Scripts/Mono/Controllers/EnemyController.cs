using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyModel _enemyModel;
    private GameBuilder _gameBuilder;

    public EnemyModel EnemyModel
    {
        get => _enemyModel;
        set => _enemyModel = value;
    }

    public void Init(GameBuilder builder)
    {
        _gameBuilder = builder;
    }

    private void Awake()
    {
        Moved();
    }

    private void Moved()
    {
        transform.DOMove(_gameBuilder.GetRandomWalkablePoint(), _enemyModel.Speed).OnComplete(Moved);
    }
}
