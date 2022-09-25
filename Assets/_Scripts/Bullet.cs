using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private bool _hasCollide = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasCollide) return;
        if (collision.gameObject.TryGetComponent<Hitable>(out var component))
        {
            _hasCollide = true;
            component.TakeDamage(1);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible() => Destroy(gameObject);
    private void Update() => transform.position += Vector3.left * Time.deltaTime * _speed;
}
