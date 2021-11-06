using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    private ColorController _colorController;
    private int _colorIndex;

    private void Start()
    {
        _colorController = FindObjectOfType<ColorController>();
    }

    public int GetColorId() => _colorIndex;
    
    public void SetColor(int colorIndex)
    {
        _colorIndex = colorIndex;
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = _colorController.GetColor(_colorIndex);
        }
    }
}
