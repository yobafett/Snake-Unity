using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SnakeMover mover;
    [SerializeField] private GameObject rayCatcher;
    
    private void OnEnable() => SnakeCollisions.OnObstacleCollide += DisableInput;
    private void OnDisable() => SnakeCollisions.OnObstacleCollide -= DisableInput;
    
    private void Update()
    {
        if (Input.GetMouseButton(0)) Move();
    }

    private void Move()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            var targetX = 0f;
            if (hit.collider.gameObject == rayCatcher)
            {
                targetX += hit.point.x > 0 ? 3.5f : -3.5f;
            }
            else
            {
                targetX += Mathf.Clamp(hit.point.x, -3.5f, 3.5f);
            }
            mover.SetMoveTarget(targetX);
        }
    }

    private void DisableInput()
    {
        this.enabled = false;
    }
}
