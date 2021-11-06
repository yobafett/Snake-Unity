using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelObjectVisible : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [FormerlySerializedAs("objCollider")] [SerializeField] private BoxCollider boxCollider;
    private bool _isVisible = true;

    public bool GetVisible() => _isVisible;

    public void SetVisible(bool state)
    {
        if(state == _isVisible) return;
        
        if (state) ShowFood();
        else HideFood();
    }

    private void HideFood()
    {
        boxCollider.enabled = false;
        _isVisible = false;
        
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
    }
    
    private void ShowFood()
    {
        boxCollider.enabled = true;
        _isVisible = true;

        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
    }
}
