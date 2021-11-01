using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SnakeMover[] movers;
    
    private void Update()
    {
        if (Input.GetMouseButton(0)) Move();
    }

    private void Move()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mainCamera.transform.position, ray.direction * 100f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var targetX = hit.point.x;
            targetX = Mathf.Clamp(targetX,-1f, 1f);

            foreach (var mover in movers)
            {
                mover.SetMoveTarget(targetX);
            }
        }
    }
    
    private Vector3 DrawRayToMousePosition(Vector3 mousePosition)
    {
        mousePosition.z = mainCamera.nearClipPlane + 0.01f;
        var position = mainCamera.ScreenPointToRay(mousePosition);
        
        Debug.DrawLine(position.origin, position.direction - (Vector3.back * 5f), Color.red);

        return position.direction;
    }
}
