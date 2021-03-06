using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelObjectRespawner : MonoBehaviour
{
    [SerializeField] private bool disableXRand;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private Transform _transform;
    private LevelObjectVisible _visible;
    private ColoredObject _color;
    private float _defaultX;
    private float _defaultY;
    private const float StartVisibleZ = 50f;
    private const float EndVisibleZ = -25f;

    private void Start()
    {
        _transform = transform;
        _visible = GetComponent<LevelObjectVisible>();
        _color = GetComponent<ColoredObject>();
        _defaultX = _transform.position.x;
        _defaultY = _transform.position.y;
    }

    void Update()
    {
        if (_transform.position.z < EndVisibleZ)
        {
            var newX = disableXRand ? _defaultX : Random.Range(minX, maxX);
            _transform.position = new Vector3(newX, _defaultY, StartVisibleZ);
            
            if(_visible) _visible.SetVisible(true);
            if(_color) _color.SetColor();
        }
    }
}
