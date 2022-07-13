using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Bar _healthBarOdject;
    [SerializeField] private float _healthChangeSpeed;
    [SerializeField] private float _chageHealthSize;

    private float _health = 100;
    private float _healthBar;
    private Coroutine _currentCorountine;

    private void Start()
    {
        _healthBar = _health;
    }

    private void Update()
    {
        _healthBarOdject.SetValue(_healthBar);
    }

    public void IncreaseDeltaHealth()
    {
        _health += _chageHealthSize;
        RestartHeathCorountine();
    }

    public void DecreaseDeltaHealth()
    {
        _health -= _chageHealthSize;
        RestartHeathCorountine();
    }

    private void RestartHeathCorountine()
    {
        if (_currentCorountine == null)
        {
            _currentCorountine = StartCoroutine(ChangeHealth());
        }

        else
        {
            StopCoroutine(_currentCorountine);
            _currentCorountine = StartCoroutine(ChangeHealth());
        }
    }

    private IEnumerator ChangeHealth()
    {
        while (_healthBar != _health)
        {
            _healthBar = Mathf.MoveTowards(_healthBar, _health, _healthChangeSpeed);
            yield return null;
        }
    }
}
