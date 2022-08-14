using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apparate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystemRenderer _psr;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Wallet _playerWallet;

    private bool _isFoundEnemy;
    private Bomb _attackBomb;

    private void Update()
    {
        if (_isFoundEnemy == false)
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }

        else
        {
            GoBack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WaveEnemy>() && _isFoundEnemy == false)
        {
            Attack(_attackBomb);
        }
    }
    public void SetBomb(Bomb newBomb)
    {
        _attackBomb = newBomb;
    }

    private void Attack(Bomb bomb)
    {
        Bomb newBomb = Instantiate(bomb, transform.position, transform.rotation);
        newBomb.SetWallet(_playerWallet);
        newBomb.SetParticles(_psr);
        StartReturnToStartPosition();
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    private void StartReturnToStartPosition()
    {
        _isFoundEnemy = true;
    }

    private void GoBack()
    {
        if (transform.position != _startPosition.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, _startPosition.position, _speed * Time.deltaTime);
        }

        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            _isFoundEnemy = false;
            gameObject.SetActive(false);
        }
    }
}
