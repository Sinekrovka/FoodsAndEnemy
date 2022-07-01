using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int HP;

    private void Awake()
    {
        //tartCoroutine(TimeUnscaleHP());
    }

    private IEnumerator TimeUnscaleHP()
    {
        yield return new WaitForSeconds(1);
        HP--;
        if (HP > 0)
        {
            StartCoroutine(TimeUnscaleHP());
            UIController.Instance.HealthBarScale = HP / 100f;
        }
        else
        {
            Dead();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyController enemyController))
        {
            HP -= enemyController.EnemyModel.Damage;
            Destroy(other.gameObject);
        }

        if (other.TryGetComponent(out FoodController food))
        {
            HP += food.FoodModel.AddedHp;
            Destroy(other.gameObject);
        }
    }

    private void Dead()
    {
        StopAllCoroutines();
        GameController.Instance.FailGame();
        UIController.Instance.HealthBarScale = HP / 100f;
    }
}
