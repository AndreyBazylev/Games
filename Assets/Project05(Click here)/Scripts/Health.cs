using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _chageHealthSize;
    [SerializeField] private UnityEvent _isIcreaseOrDecrease;

    private float _health = 100;

    public void IncreaseDeltaHealth()
    {
        _health += _chageHealthSize;
        _isIcreaseOrDecrease.Invoke();
    }

    public void DecreaseDeltaHealth()
    {
        _health -= _chageHealthSize;
        _isIcreaseOrDecrease.Invoke();
    }

    public float GetHealthValue()
    {
        return _health;
    }
}
