using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private int _colorsLength;
    
    private void Start()
    {
        _colorsLength = _colors.Length;
    }

    public Color GetColor(int index)
    {
        if (index < 0 || index >= _colorsLength)
        {
            return _colors[_colorsLength - 1];
        }
        return _colors[index];
    }

    public int GetRandomIndex()
    {
        return Random.Range(0, _colorsLength - 1);
    }
}
