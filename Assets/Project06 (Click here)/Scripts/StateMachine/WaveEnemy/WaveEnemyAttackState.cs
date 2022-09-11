using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyAttackState : State
{
    [SerializeField] protected AudioClip AttackSound;

    protected const string IsNextToPlayer = "IsNextToPlayer";
    
    protected WaitForSeconds _waitTime;

    private void OnDisable()
    {
        Animator.SetBool(IsNextToPlayer, false);
    }

    public virtual void StartAttack(Health health, float damage)
    {
        StartCoroutine(Attacking(health, damage));
    }

    protected IEnumerator Attacking(Health health, float damage)
    {
        while (health.GetComponent<Health>().GetLiveState())
        {
            GetComponent<AudioSource>().PlayOneShot(AttackSound);
            Attack(health, damage);
            yield return _waitTime;
        }

        StartCoroutine(Attacking(health, damage));
    }

    protected virtual void Attack(Health health, float damage)
    {
        Animator.SetBool(IsNextToPlayer, true);
        health.TakeDamage(damage);
    }
}
