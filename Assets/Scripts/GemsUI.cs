using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemsUI : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    private void OnEnable() => SnakeFever.OnGemsCountChange += UpdateHealth;
    private void OnDisable() => SnakeFever.OnGemsCountChange -= UpdateHealth;
    public void Start() => _textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    private void UpdateHealth(int value) => _textMesh.text = value.ToString();
}
