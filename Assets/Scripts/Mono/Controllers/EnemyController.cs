using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyModel _enemyModel;

    public EnemyModel Enemy_Model
    {
        get => _enemyModel;
        set => _enemyModel = value;
    }

    public void Moved()
    {
        Vector3 endPoint = GameBuilder.Instance.GetRandomWalkablePoint();
       transform.DOMove(endPoint, Vector3.Distance(transform.position, endPoint)).OnComplete(Moved);
    }
}
