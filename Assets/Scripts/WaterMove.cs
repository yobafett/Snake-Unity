using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float speed;
    private float _counter = 0f;

    void Update()
    {
        material.mainTextureOffset = new Vector2(_counter, 0f);
        _counter += speed;

        if (_counter > int.MaxValue) _counter = 0f;
    }
}
