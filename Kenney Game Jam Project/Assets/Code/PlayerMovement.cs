using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput _input;
    SpriteRenderer _renderer;
    Rigidbody2D _rigidbody;

    [SerializeField] float groundSpeed = 4;
    //[SerializeField] float airSpeed = 1.5f;

    float _xAxis;

    private void Awake()
    {
        _input = FindObjectOfType<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        _input.actions["Movement"].performed += OnMovement;
        _input.actions["Movement"].canceled += OnMovement;
    }

    private void OnDestroy()
    {
        _input.actions["Movement"].performed -= OnMovement;
        _input.actions["Movement"].canceled -= OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        _xAxis = context.ReadValue<Vector2>().x;

        if (Mathf.Abs(_xAxis) > 0)
            FlipSprite(_xAxis);
    }

    private void FlipSprite(float xAxis)
    {
        _renderer.flipX = xAxis >= 0;
    }

    void Update()
    {
        if(_xAxis != 0)
        {
            _rigidbody.velocity = new Vector2( _xAxis * groundSpeed, _rigidbody.velocity.y);
        }
    }
}
