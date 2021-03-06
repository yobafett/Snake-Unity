using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFever : MonoBehaviour
{
    public delegate void SnakeFeverEventHandler(int count);
    public static event SnakeFeverEventHandler OnGemsCountChange;

    [SerializeField] private PlayerInput playerInput;
    private const float FeverTime = 5f;
    private int _gemsCount;
    private bool _isFever;
    private SnakeMover _mover;
    private LevelMover _levelMover;

    private void Start()
    {
        _levelMover = FindObjectOfType<LevelMover>();
        _mover = GetComponent<SnakeMover>();
    }

    public void AddGem()
    {
        if(_gemsCount == 3 || _isFever) return;
        
        _gemsCount++;
        OnGemsCountChange?.Invoke(_gemsCount);

        if (_gemsCount < 3) return;

        _isFever = true;
        playerInput.enabled = false;
        _mover.SetMoveTarget(0f);
        _levelMover.SetSpeedModif(3);
        Invoke(nameof(DisableFever), FeverTime);
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
        playerInput.enabled = true;
        _levelMover.SetSpeedModif(1);
        ClearGems();
    } 
}
