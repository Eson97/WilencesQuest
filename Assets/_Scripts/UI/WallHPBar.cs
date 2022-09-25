using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHPBar : MonoBehaviour
{
    [SerializeField] Image progress;

    private void Start()
    {
        UpdateBar();
    }

    private void OnEnable() => Wall.OnWallTakeDamage += UpdateBar;
    private void OnDisable() => Wall.OnWallTakeDamage -= UpdateBar;

    private void UpdateBar()
    {
        float amount = ((Wall.HP * 100f) / Wall.MaxHP)/100f;
        progress.fillAmount = amount;
    }
}
