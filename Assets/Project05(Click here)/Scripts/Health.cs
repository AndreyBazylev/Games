using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public event Action<float, float> HealthIcreasedOrDecreased;
    [SerializeField] private float _chageHealthSize;
    [SerializeField] private float _maxHealth;

    [SerializeField]  float _health;

    private void Start()
    {
        _maxHealth = 100;
        _health = _maxHealth;
        HealthIcreasedOrDecreased?.Invoke(_health, _maxHealth);
    }

    public void Hil()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth) + _chageHealthSize;
        HealthIcreasedOrDecreased?.Invoke(_health, _maxHealth);   
    }

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth) - _chageHealthSize;
        HealthIcreasedOrDecreased?.Invoke(_health, _maxHealth);
    }
}
