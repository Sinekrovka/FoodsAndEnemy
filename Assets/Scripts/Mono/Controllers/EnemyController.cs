using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyModel _enemyModel;

    public EnemyModel EnemyModel
    {
        get => _enemyModel;
        set => _enemyModel = value;
    }

    private void Awake()
    {
        Moved();
    }

    private void Moved()
    {
       //transform.DOMove(GameBuilder.Instance.GetRandomWalkablePoint(), _enemyModel.Speed).OnComplete(Moved);
    }
}
