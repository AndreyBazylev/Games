using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private int _priceForDead;

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public float GetDamage()
    {
        return _damage;
    }

    public float GetHealth()
    {
        return _health;
    }

    public int GetPrice()
    {
        return _priceForDead;
    }
}
