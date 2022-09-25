using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private Stats _stats;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _level;

    public Stats Stats => _stats;
    public GameObject Enemy => _enemy;
    public int Level => _level;
}
