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
    [SerializeField] private WaveEnemyDieState _die;
    [SerializeField] private WaveEnemyIdleState _idle;
    [SerializeField] private WaveEnemyGoingState _going;
    [SerializeField] private WaveEnemyAttackState _attack;

    [SerializeField] private WaveEnemy _enemy;

    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private UnityEvent _enemyWentTrigger;

    private Coroutine _currentCorountine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            _enemyWentTrigger?.Invoke();
            _attack.enabled = true;
            _going.enabled = false;
            _currentCorountine = StartCoroutine(_attack.StartAttack(collision, _enemy.GetDamage()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            _enemyWentTrigger?.Invoke();
            _attack.enabled = false;
            StopCoroutine(_currentCorountine);
        }
    }

    private void Update()
    {
        if (_enemy.GetHealth() < 1)
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
