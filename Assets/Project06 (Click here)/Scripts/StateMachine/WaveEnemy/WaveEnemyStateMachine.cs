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
    [SerializeField] protected WaveEnemyDieState _die;
    [SerializeField] protected WaveEnemyIdleState _idle;
    [SerializeField] protected WaveEnemyGoingState _going;
    [SerializeField] protected WaveEnemyAttackState _attack;

    [SerializeField] protected WaveEnemy _enemy;

    [SerializeField] protected Wallet _playerWallet;
    [SerializeField] protected UnityEvent _enemyWentTrigger;

    private EnemyHealth _health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            _enemyWentTrigger?.Invoke();
            _attack.enabled = true;
            _going.enabled = false;
            _attack.StartAttack(collision, _enemy.Damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            _enemyWentTrigger?.Invoke();
            _attack.enabled = false;
        }
    }

    private void Update()
    {
        if (_health.Health < 1)
        {
            _die.SetWallet(_playerWallet);

            _attack.enabled = false;
            _going.enabled = false;
            _idle.enabled = false;
            _die.enabled = true;
        }
    }

    public void SetWallet(Wallet wallet)
    {
        _playerWallet = wallet;
    }
}
