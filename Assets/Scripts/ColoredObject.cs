using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private ColorsScriptableObject colors;
    private int _colorId;

    private void Start() => SetColor(0);
    
    public int GetColorId() => _colorId;

    public void SetColor(int colorIndex = -1)
    {
        _colorId = colorIndex < 0 
            ? colors.GetRandomColorId(_colorId) : colorIndex;
        var color = colors.GetColorById(_colorId);

        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = color;
        }
    }
}
