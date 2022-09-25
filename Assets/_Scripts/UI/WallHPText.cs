using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallHPText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private void Start()
    {
        UpdateText();
    }

    private void OnEnable() => Wall.OnWallTakeDamage += UpdateText;
    private void OnDisable() => Wall.OnWallTakeDamage -= UpdateText;

    private void UpdateText()
    {
        _text.text = $"Wall HP: {Wall.HP} / {Wall.MaxHP}";
    }
}
