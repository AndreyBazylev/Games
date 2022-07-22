using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyDieState : State
{
    private const string IsDead = "IsDead";
    private const string Delete = "Delete";

    private void Start()
    {
        _stateName = "Die";
    }

    private void OnEnable()
    {
        _stateAnimator.SetBool(IsDead, true);
    }

    private void Update()
    {
        var animatorStateInfo = _stateAnimator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(Delete))
        {
            Destroy(gameObject);
        }
    }
}
