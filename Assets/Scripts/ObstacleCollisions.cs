using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisions : MonoBehaviour, ILevelObjectCollisions
{
    private LevelObjectVisible _visible;
    
    private void Start()
    {
        _visible = GetComponent<LevelObjectVisible>();
    }
    
    public void MakeCollision(GameObject player)
    {
        if (player.GetComponent<SnakeFever>().IsFever()) _visible.SetVisible(false);
        else player.GetComponent<SnakeCollisions>().InvokeObstacleCollide();
    }
}
