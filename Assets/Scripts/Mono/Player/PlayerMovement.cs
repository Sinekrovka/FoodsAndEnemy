using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject _player;
    private bool moved;
    public void Init(InputController input)
    {
        moved = false;
        input.touchPoint += CheckTouch;
    }

    private void Awake()
    {
        _player = Resources.Load<GameObject>("Prefabs/Player/PlayerStandart");
        Instantiate(_player);
    }

    private void CheckTouch(Vector3 newForward, Transform cell)
    {
        if (cell.GetComponent<TileController>().Walkable())
        {
            if (moved)
            {
                _player.transform.DOKill(false);
                _player.transform.DOMove(newForward, Vector3.Distance(_player.transform.position, newForward))
                    .OnComplete(delegate { moved = false; });
            }
            else
            {
                _player.transform.DOMove(newForward, Vector3.Distance(_player.transform.position, newForward))
                    .OnComplete(delegate { moved = false; });
                moved = true;
            }
        }
    }
}
