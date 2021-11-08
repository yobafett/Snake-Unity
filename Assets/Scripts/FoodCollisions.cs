using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisions : MonoBehaviour, ILevelObjectCollisions
{
    private ColoredObject _foodColor;
    private LevelObjectVisible _visible;
    
    private void Start()
    {
        _foodColor = GetComponent<ColoredObject>();
        _visible = GetComponent<LevelObjectVisible>();
    }
    
    public void MakeCollision(GameObject player)
    {
        var isSameColor = player.gameObject.GetComponent<ColoredObject>().GetColorId() == _foodColor.GetColorId();
        if (isSameColor || player.GetComponent<SnakeFever>().IsFever()) _visible.SetVisible(false);
        else player.GetComponent<SnakeCollisions>().InvokeObstacleCollide();
    }
}
