using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnakeMover : MonoBehaviour
{
    [SerializeField][Range(2f, 10f)] private float maxSpeed;
    [SerializeField][Range(0.1f, 2f)] private float minSpeed;
    [SerializeField] private Transform[] tail;
    private Transform _transform;
    private Vector3 _moveTarget;
    private bool _isMoving;
    private float _progress;
    private float _defaultZ;
    private float _defaultY;
    private float _decreaseModifier;

    private void Start()
    {
        _transform = transform;
        var lPos = _transform.localPosition;
        _defaultZ = lPos.z;
        _defaultY = lPos.y;
        _decreaseModifier = (maxSpeed - minSpeed) / tail.Length;
    }
    
    private void Update()
    {
        if (_isMoving)
        {
            Moving(_transform, maxSpeed, _moveTarget);
            for (var i = 0; i < tail.Length; i++)
            {
                Moving(tail[i], maxSpeed - (_decreaseModifier * (i + 1)),
                    new Vector3(_moveTarget.x, _defaultY, tail[i].position.z));
            }
        }
    }

    public void SetMoveTarget(float targetX)
    {
        _moveTarget = new Vector3(targetX, _defaultY, _defaultZ);
        _progress = 0f;
        _isMoving = true;
    }
    
    private void Moving(Transform objectTransform, float speed, Vector3 moveTarget)
    {
        objectTransform.position = Vector3.Lerp(objectTransform.position, moveTarget, speed * Time.deltaTime);
        _progress = Mathf.Lerp(_progress, 1f, speed * Time.deltaTime);
        if (_progress > 0.99f)
        {
            _isMoving = false;
        }
    }
}
