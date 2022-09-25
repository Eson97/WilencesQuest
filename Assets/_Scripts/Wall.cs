using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int _maxHP = 10;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private GameObject _Statues;
    [SerializeField] private Canvas _resultCanvas;
    [SerializeField] private TextMeshProUGUI _resultText;
    public static int HP;
    public static int MaxHP;

    private void Awake()
    {
        HP = _maxHP;
        MaxHP = _maxHP;
    }

    public static Action OnWallTakeDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyAI>(out var component))
        {
            component.AttackDelegate += ReciveAttack;
        }
    }
    private void ReciveAttack()
    {
        HP--;
        AudioSystem.Instance.PlaySound(_hitSound, 0.5f);
        OnWallTakeDamage?.Invoke();
        if (HP <= 0)
        {
            HP = 0;
            GetComponent<BoxCollider2D>().enabled = false;
            _Statues.SetActive(false);
            StartCoroutine(StartLose());
            
        }
    }

    private IEnumerator StartLose()
    {
        var player = GameObject.FindWithTag("Player");

        player.GetComponent<PlayerActions>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        _resultText.text = "You Lose!";
        _resultCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        
        player.GetComponent<PlayerActions>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;

        GameManager.Instance.ChangeState(GameState.Lose);
    }

}
