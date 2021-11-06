using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelObjectSpawner : MonoBehaviour
{
    [SerializeField] private bool randomiseX;
    
    private Transform _transform;
    private float _defaultX;
    private float _defaultY;
    private LevelObjectVisible _visible;

    private void Start()
    {
        _transform = transform;
        var pos = _transform.position;
        _defaultX = pos.x;
        _defaultY = pos.y;
        _visible = GetComponent<LevelObjectVisible>();
    }

    void FixedUpdate()
    {
        if (transform.position.z < -10f)
        {
            var xPos = randomiseX ? Random.Range(-0.8f, 0.8f) : _defaultX;
            _transform.position = new Vector3(xPos, _defaultY, 10f);
            if (_visible)
            {
                _visible.SetVisible(true);
            }
        }
    }
}
