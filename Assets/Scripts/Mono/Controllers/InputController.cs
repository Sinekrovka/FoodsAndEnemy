using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Action<Vector3, Transform> touchPoint;
    private Camera main;
    public void Init()
    {
        main = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if (hit.collider != null)
            {
                touchPoint?.Invoke(hit.point, hit.transform);
            }
        }
    }
}
