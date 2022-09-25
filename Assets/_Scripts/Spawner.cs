using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Spawns;
    [SerializeField] private int _maxEnemiesCount = 10;
    [SerializeField] private float _spawnRatio = 1f;
    [SerializeField] private int _levelMin = 1;
    [SerializeField] private int _levelMax = 1;
    [SerializeField] private AudioClip _spawnSound;
    [SerializeField] private Canvas _resultCanvas;
    [SerializeField] private TextMeshProUGUI _resultText;
    private float _spawnDelay = 0f;
    private int _spawnCount = 0;
    private List<EnemySO> Enemies;
    private bool _win = false;
    private System.Random _random = new System.Random(12345);

    public static int RemainingEnemies;
    public static Action OnEnemySpawn;

    private void Awake() => RemainingEnemies = _maxEnemiesCount;
    private void Start()
    {
        Enemies = ResourceSystem.Instance.GetEnemiesOfRank(_levelMin, _levelMax);
        Debug.Log(Enemies.Count);_spawnDelay = Time.time + 1f;
    }
    private void Update()
    {
        if (_win) return;

        if(RemainingEnemies == 0 && GameObject.FindWithTag("Enemy") == null)
        {
            _win = true;
            StartCoroutine(StartWin());
        }

        if (Time.time > _spawnDelay && RemainingEnemies > 0)
        {
            _spawnDelay = Time.time + _spawnRatio;

            var enemy = _random.Next(0, Enemies.Count - 1);
            var spawn = _random.Next(0, Spawns.Count - 1);
            
            Instantiate(Enemies[enemy].Enemy, Spawns[spawn].transform.position, Quaternion.identity);
            AudioSystem.Instance.PlaySound(_spawnSound, 0.5f);

            _spawnCount++;
            if (_spawnCount >= _maxEnemiesCount)
                _spawnCount = _maxEnemiesCount;
            
            RemainingEnemies = _maxEnemiesCount - _spawnCount;
            OnEnemySpawn?.Invoke();

            //if(RemainingEnemies <= 0)
            //    gameObject.SetActive(false);
        }
    }


    private IEnumerator StartWin()
    {
        var player = GameObject.FindWithTag("Player");

        player.GetComponent<PlayerActions>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        _resultText.text = "You Win!";
        _resultCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        player.GetComponent<PlayerActions>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;

        GameManager.Instance.ChangeState(GameState.Win);
    }
}
