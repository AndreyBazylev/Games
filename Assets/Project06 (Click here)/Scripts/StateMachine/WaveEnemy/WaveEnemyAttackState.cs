using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyAttackState : State
{
    protected WaitForSeconds _waitTime;

    protected const string IsNextToPlayer = "IsNextToPlayer";

    private void Start()
    {
        _stateName = "Attack";
        _waitTime = new WaitForSeconds(2.5f);

        if (_isStartState)
        {
            _stateAnimator.SetBool(IsNextToPlayer, true);
        }
    }

    private void OnDisable()
    {
        _stateAnimator.SetBool(IsNextToPlayer, false);
    }

    public virtual void StartAttack(Collider2D collision, float damage)
    {
        StartCoroutine(Attacking(collision, damage));
    }

    protected IEnumerator Attacking(Collider2D collision, float damage)
    {
        while (collision.GetComponent<Health>().GetHealth() > 0)
        {
            Attack(collision, damage);
            yield return _waitTime;
        }

        StartCoroutine(Attacking(collision, damage));
    }

    protected virtual void Attack(Collider2D collision, float damage)
    {
        _stateAnimator.SetBool(IsNextToPlayer, true);
        collision.GetComponent<Health>().TakeDamage(damage);
    }
}
