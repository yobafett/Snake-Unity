using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisions : MonoBehaviour, ILevelObjectCollisions
{
    private FoodColor _foodColor;
    private LevelObjectVisible _visible;
    
    private void Start()
    {
        _foodColor = GetComponent<FoodColor>();
        _visible = GetComponent<LevelObjectVisible>();
    }
    
    public void MakeCollision(GameObject player)
    {
        var isSameColor = player.gameObject.GetComponent<SnakeColor>().GetColorId() == _foodColor.GetColorId();
        if (isSameColor || player.GetComponent<SnakeFever>().IsFever()) _visible.SetVisible(false);
        else player.GetComponent<SnakeCollisions>().InvokeObstacleCollide();
    }
}
