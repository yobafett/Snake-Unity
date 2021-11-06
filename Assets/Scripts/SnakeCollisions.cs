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
    private SnakeFever _snakeFever;

    private void Start()
    {
        _obstacleTag = UnityEditorInternal.InternalEditorUtility.tags[7];
        _foodTag = UnityEditorInternal.InternalEditorUtility.tags[8];
        _gemTag = UnityEditorInternal.InternalEditorUtility.tags[9];
        _checkPointTag = UnityEditorInternal.InternalEditorUtility.tags[10];
        _snakeColor = GetComponent<SnakeColor>();
        _snakeFever = GetComponent<SnakeFever>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_obstacleTag))
        {
            if (_snakeFever.IsFever())
            {
                other.gameObject.GetComponent<LevelObjectVisible>().SetVisible(false);
            }
            else
            {
                OnObstacleCollide?.Invoke();
            }
        }
        else if (other.gameObject.CompareTag(_foodTag))
        {
            var isSameColor = other.gameObject.GetComponent<FoodColor>().GetColorId() == _snakeColor.GetColorId();
            if (_snakeFever.IsFever() || isSameColor)
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
            _snakeFever.AddGem();
        }
        else if (other.gameObject.CompareTag(_checkPointTag))
        {
            var checkPointColor = other.gameObject.GetComponent<CheckPointColor>().GetColorId();
            _snakeColor.SetColor(checkPointColor);
        }
    }
}
