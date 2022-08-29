using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : WaveEnemyAttackState
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private WaveEnemy _waveEnemy;

    private const string IsFoundPlayer = "IsFoundPlayer";

    private void Start()
    {
        _stateName = "Attack";

        if (_isStartState)
        {
            _stateAnimator.SetBool(IsNextToPlayer, true);
        }
    }

    private void OnEnable()
    {
        _laser.SetActive(true);
        _stateAnimator.SetBool(IsNextToPlayer, true);
        _stateAnimator.SetBool(IsFoundPlayer, false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            StartAttack(collision, _waveEnemy.GetDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _laser.SetActive(false);
        _stateAnimator.SetBool(IsNextToPlayer, false);
        _stateAnimator.SetBool(IsFoundPlayer, true);
    }

    public override void StartAttack(Collider2D collision, float damage)
    {
        if (collision.GetComponent<Health>().GetHealth() > 0)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
