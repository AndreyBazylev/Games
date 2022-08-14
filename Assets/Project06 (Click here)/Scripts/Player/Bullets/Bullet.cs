﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _bulletSpeed;
    [SerializeField] protected float _bulletDamage;
    [SerializeField] protected Wallet _playerWallet;

    void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WaveEnemy>())
        {
            GiveDamage(collision.gameObject);
        }
    }

    public void SetWallet(Wallet wallet)
    {
        _playerWallet = wallet;
    }

    protected virtual void GiveDamage(GameObject waveEnemy)
    {
        waveEnemy.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
        waveEnemy.GetComponent<WaveEnemy>().TakeDamage(_bulletDamage);
        Destroy(gameObject);
    }
}
