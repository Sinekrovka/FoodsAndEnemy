using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void Init(InputController input)
    {
        input.touchPoint += CheckTouch;
    }

    private void CheckTouch(Vector3 newForward, Transform cell)
    {
        
    }

    private void StartMoving()
    {
        
    }
}
