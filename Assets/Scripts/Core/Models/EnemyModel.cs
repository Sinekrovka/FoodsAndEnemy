using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private int _damage;
    private float _speed;
    private int _hp;

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public int HP
    {
        get => _hp;
        set => _hp = value;
    }
}
