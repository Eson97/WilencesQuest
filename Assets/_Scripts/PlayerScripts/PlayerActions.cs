using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private AudioClip _bulletSound;
    [SerializeField] private bool _canShoot=false;
    [SerializeField] private float _fireRate = 1f;
    private float _fireDelay = 0f;

    private PlayerInput _input;

    private InputAction _interactAction;
    private InputAction _fireAction;

    public Action InteractDelegate;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();

        _interactAction = _input.actions["Interact"];
        _fireAction = _input.actions["Fire"];
    }
    private void OnEnable()
    {
        _interactAction.performed += Interact;
        _fireAction.performed += Fire;
    }
    private void OnDisable()
    {
        _interactAction.performed -= Interact;
        _fireAction.performed -= Fire;
    }

    private void Fire(InputAction.CallbackContext ctx)
    {
        if (_canShoot)
        {
            if (Time.time > _fireDelay)
            {
                _fireDelay = Time.time + _fireRate;

                Instantiate(_bullet, _bulletSpawner.position, Quaternion.identity);
                if (_bulletSound != null) AudioSystem.Instance.PlaySound(_bulletSound);
            }
        }
    }


    private void Interact(InputAction.CallbackContext ctx) => InteractDelegate?.Invoke();

}
