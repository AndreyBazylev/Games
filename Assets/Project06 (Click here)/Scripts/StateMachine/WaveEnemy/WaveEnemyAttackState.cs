using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyAttackState : State
{
    private WaitForSeconds _waitTime;

    private const string IsNextToPlayer = "IsNextToPlayer";

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

    public IEnumerator StartAttack(Collider2D collision, float damage)
    {
        while (collision.GetComponent<Health>().GetHealth() > 0)
        {
            Attack(collision, damage);
            yield return _waitTime;
        }
    }

    private void Attack(Collider2D collision, float damage)
    {
        _stateAnimator.SetBool(IsNextToPlayer, true);
        collision.GetComponent<Health>().TakeDamage(damage);
    }
}
