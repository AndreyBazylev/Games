using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public event Action<float, float> IsIcreaseOrDecrease;
    [SerializeField] private float _chageHealthSize;
    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _maxHealth = 100;
        _health = _maxHealth;
        IsIcreaseOrDecrease?.Invoke(_health, _maxHealth);
    }

    public void IncreaseDeltaHealth()
    {
        if(_health + _chageHealthSize <= _maxHealth)
        {
            _health += _chageHealthSize;
            IsIcreaseOrDecrease?.Invoke(_health, _maxHealth);
        }    
    }

    public void DecreaseDeltaHealth()
    {
        if (_health - _chageHealthSize <= _maxHealth)
        {
            _health -= _chageHealthSize;
            IsIcreaseOrDecrease?.Invoke(_health, _maxHealth);
        }
    }
}
