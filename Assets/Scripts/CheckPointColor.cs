using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CheckPointColor : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private ColorController _colorController;
    private int _colorIndex;


    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _colorController = FindObjectOfType<ColorController>();
        SetColor(_colorController.GetRandomIndex());
    }

    public void SetNewColor()
    {
        var newIndex = _colorController.GetRandomIndex();
        while (newIndex == _colorIndex)
        {
            newIndex = _colorController.GetRandomIndex();
        }
        
        SetColor(newIndex);
    }

    public int GetColorId() => _colorIndex;
    
    private void SetColor(int colorIndex)
    {
        _colorIndex = colorIndex;
        _meshRenderer.material.color = _colorController.GetColor(_colorIndex);
    }
}
