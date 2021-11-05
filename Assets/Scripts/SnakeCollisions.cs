using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisions : MonoBehaviour
{
    public delegate void SnakeCollisionsEventHandler();
    public static event SnakeCollisionsEventHandler onObstacleCollide;
    
    private string _obstacleTag;

    private void Start()
    {
        _obstacleTag = UnityEditorInternal.InternalEditorUtility.tags[7];
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_obstacleTag))
        {
            onObstacleCollide?.Invoke();
        }
    }
}
