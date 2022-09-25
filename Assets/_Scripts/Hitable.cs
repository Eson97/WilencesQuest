using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    [SerializeField] private EnemySO _enemyData;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;
    private int HP;

    private void Awake() => HP = _enemyData.Stats.HP;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            AudioSystem.Instance.PlaySound(_deathSound, 0.5f);
            Destroy(gameObject);
        }
        else
        {
            AudioSystem.Instance.PlaySound(_hitSound, 0.5f);
        }
    }

}
