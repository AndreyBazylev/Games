using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected string _stateName;
    [SerializeField] protected Animator _stateAnimator;
    [SerializeField] protected bool _isStartState;
}
