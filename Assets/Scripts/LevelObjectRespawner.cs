using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelObjectRespawner : MonoBehaviour
{
    [SerializeField] private bool disableXRand;
    private Transform _transform;
    private LevelObjectVisible _visible;
    private FoodColor _foodColor;
    private CheckPointColor _checkPointColor;
    private float _defaultX;
    private float _defaultY;
    private const float StartVisibleZ = 10f;
    private const float EndVisibleZ = -10f;

    private void Start()
    {
        _transform = transform;
        _visible = GetComponent<LevelObjectVisible>();
        _foodColor = GetComponent<FoodColor>();
        _checkPointColor = GetComponent<CheckPointColor>();
        _defaultX = _transform.position.x;
        _defaultY = _transform.position.y;
    }

    void Update()
    {
        if (_transform.position.z < EndVisibleZ)
        {
            var newX = disableXRand ? _defaultX : Random.Range(-0.8f, 0.8f);
            _transform.position = new Vector3(newX, _defaultY, StartVisibleZ);
            
            if(_visible) _visible.SetVisible(true);
            
            if(_foodColor) _foodColor.SetNewColor();
            else if(_checkPointColor) _checkPointColor.SetNewColor();
        }
    }
}