using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class WalkingObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrenght;
    [SerializeField] private Animator _playerAnoimator;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private const string IsWalking = "IsWalking";
    private const string Jump = "Jump";

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _playerAnoimator.SetBool(IsWalking, true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0); 
            _playerAnoimator.SetBool(IsWalking, true);
        }

        else
        {
            _playerAnoimator.SetBool(IsWalking, false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerAnoimator.SetTrigger(Jump);
            _rigidbody2D.AddForce(Vector2.up * _jumpStrenght);
        }
    }
}
