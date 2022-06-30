using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpStrenght;
    [SerializeField] Animator _playerAnoimator;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private const string IsWalkingAnimator = "IsWalking";
    private const string JumpAnimator = "Jump";

    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _playerAnoimator.SetBool(IsWalkingAnimator, true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0); 
            _playerAnoimator.SetBool(IsWalkingAnimator, true);
        }

        else
        {
            _playerAnoimator.SetBool(IsWalkingAnimator, false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerAnoimator.SetTrigger(JumpAnimator);
            _rigidbody2D.AddForce(Vector2.up * _jumpStrenght);
        }
    }
}
