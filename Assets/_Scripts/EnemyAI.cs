using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State _state = State.walking;
    [SerializeField] private EnemySO _enemyData;
    private float _attackDelay = 0f;

    private Animator _animator;

    public Action AttackDelegate;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start() => _animator?.SetBool("isMoving", true);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PlayerBorder")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.gameObject.tag == "Wall")
        {
            _state = State.attacking;
            _attackDelay = Time.time + _enemyData.Stats.AttackRate;
            _animator?.SetBool("isMoving", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            _state = State.walking;
        }
    }
    private void FixedUpdate()
    {
        if(_state == State.walking)
        {
            var vector = Vector3.right * _enemyData.Stats.MovementSpeed * Time.fixedDeltaTime;
            transform.position += vector;
        }
        else
        {
            if (Time.time > _attackDelay)
            {
                _attackDelay = Time.time + _enemyData.Stats.AttackRate;
                AttackDelegate?.Invoke();
            }
        }        
    }


    internal enum State { walking,attacking }
}
