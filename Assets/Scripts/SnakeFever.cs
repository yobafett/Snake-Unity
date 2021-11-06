using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFever : MonoBehaviour
{
    public delegate void SnakeFeverEventHandler(int count);
    public static event SnakeFeverEventHandler OnGemsCountChange;

    [SerializeField] [Range(1f, 10f)] private float feverTime;
    private int _gemsCount = 0;
    private bool _isFever;
    private PlayerInput _playerInput;
    private SnakeMover _mover;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _mover = GetComponent<SnakeMover>();
    }

    public void AddGem()
    {
        if(_gemsCount == 3 || _isFever) return;
        
        _gemsCount++;
        OnGemsCountChange?.Invoke(_gemsCount);

        if (_gemsCount < 3) return;

        _isFever = true;
        _playerInput.enabled = false;
        _mover.SetMoveTarget(0f);
        Invoke(nameof(DisableFever), feverTime);
    }

    public bool IsFever() => _isFever;
    
    private void ClearGems()
    {
        _gemsCount = 0;
        OnGemsCountChange?.Invoke(_gemsCount);
    }

    private void DisableFever()
    {
        _isFever = false;
        _playerInput.enabled = true;
        ClearGems();
    } 
}
