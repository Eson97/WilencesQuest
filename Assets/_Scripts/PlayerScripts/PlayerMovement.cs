using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private bool _onlyXAxis = false;
    [SerializeField] private bool _onlyYAxis = false;
    [SerializeField] private bool _freezeSprite = false;
    [SerializeField] private AudioClip _stepsSound;
    
    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private InputAction _moveAction;
    private PlayerInput _input;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();

        _moveAction = _input.actions["Move"];
    }
    private void OnEnable()
    {
        _moveAction.performed += GetDirection;
        _moveAction.canceled += resetDirection;
    }
    private void OnDisable()
    {
        _moveAction.performed -= GetDirection;
        _moveAction.canceled -= resetDirection;
    }

    private void FixedUpdate()
    {

        var vector = _direction * _movementSpeed * Time.fixedDeltaTime;
        if (vector != Vector2.zero)
        {
            if (_onlyXAxis) vector.y = 0;
            if (_onlyYAxis) vector.x = 0;

            if (!_freezeSprite)
            {
                if (vector.x > 0.01f && !_spriteRenderer.flipX)
                    _spriteRenderer.flipX = true;
                else if (vector.x < -0.01f && _spriteRenderer.flipX)
                    _spriteRenderer.flipX = false;
            }

            _rigidbody2D.MovePosition(_rigidbody2D.position + vector);
            //AudioSystem.Instance.PlaySound(_stepsSound, 0.8f);
        }
        _animator.SetFloat("Speed", vector.normalized.magnitude);
    }

    private void GetDirection(InputAction.CallbackContext ctx) => _direction = ctx.ReadValue<Vector2>();
    private void resetDirection(InputAction.CallbackContext ctx) => _direction = Vector2.zero;
}
