using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    [SerializeField][Range(0.1f, 1f)] private float speed;
    private Transform _transform;
    private bool _move;

    private void OnEnable() => SnakeCollisions.onObstacleCollide += LevelStop;
    private void OnDisable() => SnakeCollisions.onObstacleCollide -= LevelStop;
    
    private void Start()
    {
        _transform = transform;
        _move = true;
    }

    void FixedUpdate()
    {
        if (_move)
        {
            var currentPosition = _transform.position;
            var newPosition = new Vector3(currentPosition.x, currentPosition.y, (currentPosition.z - speed));
            _transform.position = newPosition;
        }
    }

    private void LevelStop()
    {
        _move = false;
    }
}
