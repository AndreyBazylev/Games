﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public event UnityAction<float, float> Changed;
    [SerializeField] private float _maxHealth = 100;

    [SerializeField]  private float _health;

    private void Start()
    {
        _health = _maxHealth;
        Changed?.Invoke(_health, _maxHealth);
    }

    public void Hil(float hilSize)
    {       
        _health = Mathf.Clamp(_health + hilSize, 0, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);   
    }

    public void TakeDamage(float damageSize)
    {  
        _health = Mathf.Clamp(_health - damageSize, 0, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);
    }
}

