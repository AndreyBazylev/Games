using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public HealthIcreasedOrDecreased Changed;
    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        Changed = new HealthIcreasedOrDecreased();
        _maxHealth = 100;
        _health = _maxHealth;
        Changed?.Invoke(_health, _maxHealth);
    }

    public void Hil(float hilSize)
    {       
        _health += hilSize;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);   
    }

    public void TakeDamage(float damageSize)
    {  
        _health -= damageSize;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);
    }
}

public class HealthIcreasedOrDecreased : UnityEvent<float, float>
{ }
