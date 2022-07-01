using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int HP;

    private void Awake()
    {
        StartCoroutine(TimeUnscaleHP());
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
        if (other.TryGetComponent(out FoodController food))
        {
            HP += food.Food_Model.AddedHp;
            other.gameObject.SetActive(false);
        }
        if (other.TryGetComponent(out EnemyController enemyController))
        {
            HP -= enemyController.Enemy_Model.Damage;
            other.gameObject.SetActive(false);
        }
        UIController.Instance.HealthBarScale = HP / 100f;
    }

    private void Dead()
    {
        StopAllCoroutines();
        GameController.Instance.FailGame();
        UIController.Instance.HealthBarScale = HP / 100f;
    }
}
