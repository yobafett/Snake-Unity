using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SnakeMover mover;
    
    private void Update()
    {
        if (Input.GetMouseButton(0)) Move();
    }

    private void Move()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            var targetX = Mathf.Clamp(hit.point.x, -1f, 1f);
            mover.SetMoveTarget(targetX);
        }
    }
}
