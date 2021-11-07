using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform _transform;
    private bool _move;

    private void OnEnable() => SnakeCollisions.OnObstacleCollide += LevelStop;
    private void OnDisable() => SnakeCollisions.OnObstacleCollide -= LevelStop;
    
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
