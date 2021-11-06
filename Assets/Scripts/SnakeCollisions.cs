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
    private string _checkPointTag;
    private SnakeColor _snakeColor;

    private void Start()
    {
        _obstacleTag = UnityEditorInternal.InternalEditorUtility.tags[7];
        _foodTag = UnityEditorInternal.InternalEditorUtility.tags[8];
        _gemTag = UnityEditorInternal.InternalEditorUtility.tags[9];
        _checkPointTag = UnityEditorInternal.InternalEditorUtility.tags[10];
        _snakeColor = GetComponent<SnakeColor>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_obstacleTag))
        {
            OnObstacleCollide?.Invoke();
        }
        else if (other.gameObject.CompareTag(_foodTag))
        {
            if (other.gameObject.GetComponent<FoodColor>().GetColorId() == _snakeColor.GetColorId())
            {
                other.gameObject.GetComponent<LevelObjectVisible>().SetVisible(false);
            }
            else
            {
                OnObstacleCollide?.Invoke();
            }
        }
        else if (other.gameObject.CompareTag(_gemTag))
        {
            other.gameObject.GetComponent<LevelObjectVisible>().SetVisible(false);
        }
        else if (other.gameObject.CompareTag(_checkPointTag))
        {
            var checkPointColor = other.gameObject.GetComponent<CheckPointColor>().GetColorId();
            _snakeColor.SetColor(checkPointColor);
        }
    }
}
