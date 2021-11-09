using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTailMover : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _moveTarget;
    private float _moveSpeed;
    private float _progress;
    private float _defaultZ;
    private float _defaultY;
    private bool _isMoving;
    
    private void Start()
    {
        _transform = transform;
        var lPos = _transform.localPosition;
        _defaultZ = lPos.z;
        _defaultY = lPos.y;
    }

    private void Update()
    {
        if (_isMoving) Moving(_transform, _moveTarget);
    }
    
    public void SetMoveTarget(Vector3 target, float speed)
    {
        _moveTarget = new Vector3(target.x, _defaultY, _defaultZ);
        _moveSpeed = speed;
        _progress = 0f;
        _isMoving = true;
    }
    
    private void Moving(Transform objectTransform, Vector3 moveTarget)
    {
        objectTransform.position = Vector3.Lerp(objectTransform.position, moveTarget, _moveSpeed * Time.deltaTime);
        _progress = Mathf.Lerp(_progress, 1f, _moveSpeed * Time.deltaTime);
        if (_progress > 0.99f)
        {
            _isMoving = false;
        }
    }
}
