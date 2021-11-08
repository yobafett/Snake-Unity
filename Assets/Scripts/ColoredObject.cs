using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    private ColorController _colorController;
    private int _colorIndex = 0;

    private void Start()
    {
        _colorController = FindObjectOfType<ColorController>();
        SetColor(0);
    }

    public int GetColorId() => _colorIndex;

    public void SetColor(int colorIndex = -1)
    {
        _colorIndex = colorIndex < 0 
            ? _colorController.GetRandomIndex() : colorIndex;
        var color = _colorController.GetColor(_colorIndex);

        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = color;
        }
    }
}
