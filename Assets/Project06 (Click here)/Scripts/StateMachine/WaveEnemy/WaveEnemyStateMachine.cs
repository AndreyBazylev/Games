using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WaveEnemyAttackState))]
[RequireComponent(typeof(WaveEnemyGoingState))]
[RequireComponent(typeof(WaveEnemyIdleState))]
[RequireComponent(typeof(WaveEnemyDieState))]
[RequireComponent(typeof(WaveEnemy))]

public class WaveEnemyStateMachine : MonoBehaviour
{
    [SerializeField] protected WaveEnemyDieState Die;
    [SerializeField] protected WaveEnemyIdleState Idle;
    [SerializeField] protected WaveEnemyGoingState Going;
    [SerializeField] protected WaveEnemyAttackState Attack;

    [SerializeField] protected WaveEnemy Enemy;

    [SerializeField] protected Wallet PlayerWallet;
    [SerializeField] protected UnityEvent EnemyWentTrigger;

    private EnemyHealth _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            EnemyWentTrigger?.Invoke();
            Attack.enabled = true;
            Going.enabled = false;
            Attack.StartAttack(collision, Enemy.Damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            EnemyWentTrigger?.Invoke();
            Attack.enabled = false;
        }
    }

    private void Update()
    {
        if (_health.Health < 1)
        {
            Die.SetWallet(PlayerWallet);

            Attack.enabled = false;
            Going.enabled = false;
            Idle.enabled = false;
            Die.enabled = true;
        }
    }

    public void SetWallet(Wallet wallet)
    {
        PlayerWallet = wallet;
    }
}
