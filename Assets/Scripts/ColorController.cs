using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private int _colorsLength;
    
    private void Awake()
    {
        _colorsLength = colors.Length;
    }

    public Color GetColor(int index)
    {
        if (index < 0 || index >= _colorsLength)
        {
            return colors[_colorsLength - 1];
        }
        return colors[index];
    }

    public int GetRandomIndex()
    {
        return Random.Range(0, _colorsLength - 1);
    }
}
