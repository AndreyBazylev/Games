using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class DroneAttack : WaveEnemyAttackState
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private WaveEnemy _waveEnemy;

    private const string IsFoundPlayer = "IsFoundPlayer";

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _laser.SetActive(true);
        Animator.SetBool(IsNextToPlayer, true);
        Animator.SetBool(IsFoundPlayer, false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            StartAttack(health, _waveEnemy.Damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audioSource.volume = 0;
        _laser.SetActive(false);
        Animator.SetBool(IsNextToPlayer, false);
        Animator.SetBool(IsFoundPlayer, true);
    }

    public override void StartAttack(Health health, float damage)
    {
        _audioSource.volume = 1;

        if (health.GetLiveState())
        {
            health.TakeDamage(damage);
        }
    }
}
