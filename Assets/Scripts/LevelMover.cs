using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    [SerializeField][Range(0.1f, 1f)] private float speed;
    private Transform _transform;
    
    private void Start()
    {
        _transform = transform;
    }

    void FixedUpdate()
    {
        var currentPosition = _transform.position;
        _transform.position = new Vector3(currentPosition.x, currentPosition.y, (currentPosition.z - speed));
    }
}
