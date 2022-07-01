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
            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                touchPoint?.Invoke(hit.point, hit.transform);
            }
        }
    }
}
