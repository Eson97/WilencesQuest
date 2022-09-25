using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void Start() => UpdateText();

    private void OnEnable() => Spawner.OnEnemySpawn += UpdateText;
    private void OnDisable() => Spawner.OnEnemySpawn -= UpdateText;

    private void UpdateText()
    {
        _text.text = $"{Spawner.RemainingEnemies}";
    }
}
