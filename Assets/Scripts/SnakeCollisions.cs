using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisions : MonoBehaviour
{
    public delegate void SnakeCollisionsEventHandler();
    public static event SnakeCollisionsEventHandler OnObstacleCollide;
    
    private string _obstacleTag;
    private string _foodTag;
    private string _gemTag;

    private void Start()
    {
        _obstacleTag = UnityEditorInternal.InternalEditorUtility.tags[7];
        _foodTag = UnityEditorInternal.InternalEditorUtility.tags[8];
        _gemTag = UnityEditorInternal.InternalEditorUtility.tags[9];
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_obstacleTag))
        {
            OnObstacleCollide?.Invoke();
        }
        else if (other.gameObject.CompareTag(_foodTag))
        {
            other.gameObject.GetComponent<LevelObjectVisible>().SetVisible(false);
        }
        else if (other.gameObject.CompareTag(_gemTag))
        {
            other.gameObject.GetComponent<LevelObjectVisible>().SetVisible(false);
        }
    }
}
