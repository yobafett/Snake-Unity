using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollisions : MonoBehaviour, ILevelObjectCollisions
{
    private ColoredObject _checkPointColor;
    
    private void Start()
    {
        _checkPointColor = GetComponent<ColoredObject>();
    }

    public void MakeCollision(GameObject player)
    {
        var checkPointColor = _checkPointColor.GetColorId();
        player.GetComponent<ColoredObject>().SetColor(checkPointColor);
    }
}