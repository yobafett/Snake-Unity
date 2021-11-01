using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnakeMover : MonoBehaviour
{
    [SerializeField] private float lerpTime;
    private Vector3 _moveTarget;
    private bool _isMoving;
    private float _progress;
    private Transform _transform;
    private float _defaultZ;
    private float _defaultY;
    
    private void Start()
    {
        _transform = transform;
        var lPos = _transform.localPosition;
        _defaultZ = lPos.z;
        _defaultY = lPos.y;
    }

    
    private void Update()
    {
        if (_isMoving) Moving();
    }

    public void SetMoveTarget(float targetX)
    {
        _moveTarget = new Vector3(targetX, _defaultY, _defaultZ);
        _progress = 0f;
        _isMoving = true;
    }
    
    private void Moving()
    {
        transform.position = Vector3.Lerp(transform.position, _moveTarget, lerpTime * Time.deltaTime);
        _progress = Mathf.Lerp(_progress, 1f, lerpTime * Time.deltaTime);
        if (_progress > 0.9f)
        {
            _isMoving = false;
        }
    }
}
