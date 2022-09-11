using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float BulletSpeed;
    [SerializeField] protected float BulletDamage;
    [SerializeField] protected Wallet PlayerWallet;
    [SerializeField] protected AudioClip Tock;

    private void Update()
    {
        transform.Translate(Vector2.up * BulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out WaveEnemy enemy))
        {
            GiveDamage(enemy);
        }
    }

    public void SetWallet(Wallet wallet)
    {
        PlayerWallet = wallet;
    }

    protected virtual void GiveDamage(WaveEnemy enemy)
    {
        enemy.StateMachine.SetWallet(PlayerWallet);
        enemy.Health.TakeDamage(BulletDamage, Tock);
        Destroy(gameObject);
    }
}
