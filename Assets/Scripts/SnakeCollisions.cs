using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeCollisions : MonoBehaviour
{
    public delegate void SnakeCollisionsEventHandler();
    public static event SnakeCollisionsEventHandler OnObstacleCollide;

    private void OnCollisionEnter(Collision other)
    {
        var iCollisions = other.gameObject.GetComponent<ILevelObjectCollisions>();
        if(!iCollisions.Equals(null)) iCollisions.MakeCollision(gameObject);
    }

    public void InvokeObstacleCollide() => OnObstacleCollide?.Invoke();
}
