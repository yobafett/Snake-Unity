using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFever : MonoBehaviour
{
    public delegate void SnakeFeverEventHandler(int count);
    public static event SnakeFeverEventHandler OnGemsCountChange;

    private int _gemsCount = 0;

    public void AddGem()
    {
        _gemsCount++;
        OnGemsCountChange?.Invoke(_gemsCount);
    }

    private void ClearGems()
    {
        _gemsCount = 0;
        OnGemsCountChange?.Invoke(_gemsCount);
    }
}
