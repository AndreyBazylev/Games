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

    public virtual void StartAttack(Collider2D collision, float damage)
    {
        StartCoroutine(Attacking(collision, damage));
    }

    protected IEnumerator Attacking(Collider2D collision, float damage)
    {
        while (collision.GetComponent<Health>().GetHealth() > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(AttackSound);
            Attack(collision, damage);
            yield return _waitTime;
        }

        StartCoroutine(Attacking(collision, damage));
    }

    protected virtual void Attack(Collider2D collision, float damage)
    {
        Animator.SetBool(IsNextToPlayer, true);
        collision.GetComponent<Health>().TakeDamage(damage);
    }
}
