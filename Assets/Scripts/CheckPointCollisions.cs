using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollisions : MonoBehaviour, ILevelObjectCollisions
{
    private CheckPointColor _checkPointColor;
    
    private void Start()
    {
        _checkPointColor = GetComponent<CheckPointColor>();
    }

    public void MakeCollision(GameObject player)
    {
        var checkPointColor = _checkPointColor.GetColorId();
        player.GetComponent<SnakeColor>().SetColor(checkPointColor);
    }
}