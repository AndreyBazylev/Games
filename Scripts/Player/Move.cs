using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpStrenght;
    [SerializeField] Animator _playerAnomator;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _playerAnomator.SetBool("IsWalking", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0); 
            _playerAnomator.SetBool("IsWalking", true);
        }

        else
        {
            _playerAnomator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerAnomator.SetTrigger("Jump");
            _rigidbody2D.AddForce(Vector2.up * _jumpStrenght);
        }
    }
}
