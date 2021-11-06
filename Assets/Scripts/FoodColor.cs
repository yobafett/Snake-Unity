using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    private ColorController _colorController;
    private int _colorIndex;

    private void Start()
    {
        _colorController = FindObjectOfType<ColorController>();
    }

    public int GetColorId() => _colorIndex;
    
    public void SetNewColor()
    {
        var newIndex = _colorController.GetRandomIndex();
        while (newIndex == _colorIndex)
        {
            newIndex = _colorController.GetRandomIndex();
        }
        
        SetColor(newIndex);
    }
    
    private void SetColor(int colorIndex)
    {
        _colorIndex = colorIndex;
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = _colorController.GetColor(_colorIndex);
        }
    }
}
