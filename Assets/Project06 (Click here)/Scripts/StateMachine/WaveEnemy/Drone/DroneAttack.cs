using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : WaveEnemyAttackState
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private WaveEnemy _waveEnemy;

    private const string IsFoundPlayer = "IsFoundPlayer";
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
            StartAttack(collision, _waveEnemy.Damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<AudioSource>().volume = 0;
        _laser.SetActive(false);
        _stateAnimator.SetBool(IsNextToPlayer, false);
        _stateAnimator.SetBool(IsFoundPlayer, true);
    }

    public override void StartAttack(Collider2D collision, float damage)
    {
        GetComponent<AudioSource>().volume = 1;

        if (collision.GetComponent<Health>().GetHealth() > 0)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
