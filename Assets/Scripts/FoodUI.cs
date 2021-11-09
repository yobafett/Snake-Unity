using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodUI : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    private int _foodCount;
    private void OnEnable() => FoodCollisions.OnFoodCountChange += UpdateFood;
    private void OnDisable() => FoodCollisions.OnFoodCountChange -= UpdateFood;
    public void Start() => _textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    private void UpdateFood(int value)
    {
        _foodCount += value;
        _textMesh.text = _foodCount.ToString();
    }
}
