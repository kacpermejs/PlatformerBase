using TarodevController;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerController _player;
    SpriteRenderer _sprite;

    private bool _grounded;
    private Vector2 _input;

    private Animator _animator;

    private void Awake() {
        _rb = GetComponentInParent<Rigidbody2D>();
        _player = GetComponentInParent<PlayerController>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        if (_rb == null ) {
            Debug.LogError("Missing Rigidbody!");
        }
    }

    private void OnEnable() {
        _player.Jumped += OnJumped;
        _player.GroundedChanged += OnGroundedChanged;

    }

    private void OnDisable() {
        _player.Jumped -= OnJumped;
        _player.GroundedChanged -= OnGroundedChanged;
    }

    private void OnGroundedChanged(bool grounded, float velocity) {
        _grounded = grounded;
        _input = _player.FrameInput;
    }

    private void OnJumped() {
        
    }

    private void HandleSpriteFlip() {
        if (_player.FrameInput.x != 0) _sprite.flipX = _player.FrameInput.x > 0;
    }

    void Update() {
        HandleSpriteFlip();

        HandleParameters();
    }

    private void HandleParameters() {
        float horizontalSpeed = Mathf.Abs(_rb.linearVelocity.x);
        float verticalSpeed = Mathf.Abs(_rb.linearVelocity.y);
        _animator.SetFloat("HorizontalSpeed", horizontalSpeed);
        _animator.SetFloat("VerticalSpeed", verticalSpeed);
        _animator.SetBool("IsGrounded", _grounded);
    }
}
