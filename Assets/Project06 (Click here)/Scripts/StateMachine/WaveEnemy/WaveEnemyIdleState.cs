using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyIdleState : State
{
    private const string IsFoundPlayer = "IsFoundPlayer";
    private void OnEnable()
    {
        _stateAnimator.SetBool(IsFoundPlayer, false);
    }
}
