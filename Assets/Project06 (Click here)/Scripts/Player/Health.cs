using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public event UnityAction<float, float> Changed;

    [SerializeField] private float _maxHealth = 100;

    private bool _isTakenDamage = false;

    public float Value { get; private set; }

    private void Start()
    {
        Value = _maxHealth;
        Changed?.Invoke(Value, _maxHealth);
    }

    public bool GetLiveState()
    {
        return Value < 1;
    }

    public void Hil(float hilSize)
    {       
        Value = Mathf.Clamp(Value + hilSize, 0, _maxHealth);
        Changed?.Invoke(Value, _maxHealth);   
    }

    public void TakeDamage(float damageSize)
    {  
        Value = Mathf.Clamp(Value - damageSize, 0, _maxHealth);
        Changed?.Invoke(Value, _maxHealth);

        _isTakenDamage = true;

        if (Value <= 0)
        {
            Die();
        }
    }

    public bool GetTakenDamage()
    {
        return _isTakenDamage;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

