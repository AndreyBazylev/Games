using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyGoingState : State
{
    [SerializeField] private float _speed;

    private const string IsFoundPlayer = "IsFoundPlayer";
    private bool _isEnemyInTrigger = false;
    private Coroutine _goToCoruontine;
    private void OnEnable()
    {
        _stateAnimator.SetBool(IsFoundPlayer, true);
        _goToCoruontine = StartCoroutine(GoToTarget());
    }

    private void OnDisable()
    {
        transform.Translate(0, 0, 0);
        _stateAnimator.SetBool(IsFoundPlayer, false);
        StopCoroutine(_goToCoruontine);
    }

    public virtual void SetEnemyPosition()
    {
        _isEnemyInTrigger = !_isEnemyInTrigger;
    }

    private IEnumerator GoToTarget()
    {
        while (_isEnemyInTrigger == false)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }
}
