using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollisions : MonoBehaviour, ILevelObjectCollisions
{
    private LevelObjectVisible _visible;
    
    private void Start()
    {
        _visible = GetComponent<LevelObjectVisible>();
    }
    
    public void MakeCollision(GameObject player)
    {
        _visible.SetVisible(false);
        player.GetComponent<SnakeFever>().AddGem();
    }
}