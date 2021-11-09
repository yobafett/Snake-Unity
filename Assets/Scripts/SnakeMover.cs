using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [SerializeField] private Transform[] tail;
    [SerializeField] private float bonesDistance;
    [SerializeField] private float moveSpeed;
    private Transform _transform;
    private Vector3 _moveTarget;
    private float _progress;
    private float _defaultZ;
    private float _defaultY;
    private float _sqrDistance;
    private bool _isMoving;

    private void Start()
    {
        _sqrDistance = Mathf.Sqrt(bonesDistance);
        _transform = transform;
        var lPos = _transform.localPosition;
        _defaultZ = lPos.z;
        _defaultY = lPos.y;
    }

    private void Update()
    {
        if (_isMoving)
        {
            Moving(_transform, _moveTarget);
            var previousPosition = transform.position;
            foreach (var bone in tail)
            {
                if ((bone.position - previousPosition).sqrMagnitude > _sqrDistance)
                {
                    bone.gameObject.GetComponent<SnakeTailMover>().SetMoveTarget(previousPosition, moveSpeed);
                    previousPosition = bone.position;
                }
                else
                {
                    break;
                }
            }
        }
    }
    
    public void SetMoveTarget(float targetX)
    {
        _moveTarget = new Vector3(targetX, _defaultY, _defaultZ);
        _progress = 0f;
        _isMoving = true;
    }
    
    private void Moving(Transform objectTransform, Vector3 moveTarget)
    {
        objectTransform.position = Vector3.Lerp(objectTransform.position, moveTarget, moveSpeed * Time.deltaTime);
        _progress = Mathf.Lerp(_progress, 1f, moveSpeed * Time.deltaTime);
        if (_progress > 1f)
        {
            _isMoving = false;
        }
    }
}
