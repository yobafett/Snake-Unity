using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelObjectSpawner : MonoBehaviour
{
    private Transform _transform;
    private float _defaultY;
    private FoodController _food;

    private void Start()
    {
        _transform = transform;
        _defaultY = _transform.position.y;
        _food = GetComponent<FoodController>();
    }

    void FixedUpdate()
    {
        if (transform.position.z < -10f)
        {
            _transform.position = new Vector3(Random.Range(-0.8f, 0.8f), _defaultY, 10f);
            if (_food)
            {
                _food.ShowFood();
            }
        }
    }
}
