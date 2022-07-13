using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _barSlider;
    [SerializeField] private Text _barText;
    [SerializeField] private Health _health;
    [SerializeField] private float _healthChangeSpeed;

    private Coroutine _currentCorountine;

    private float _value;

    private void Start()
    {
        _health.HealthIcreasedOrDecreased += RestartHeathCorountine;
    }

    public void RestartHeathCorountine(float health, float _maxHealth)
    {
        _barSlider.maxValue = _maxHealth;

        if(_currentCorountine != null)
            StopCoroutine(_currentCorountine);

        _currentCorountine = StartCoroutine(ChangeHealth(health, _maxHealth));
    }

    private void PrintValue()
    {
        _barText.text = Convert.ToString(Convert.ToInt32(_value)) + '%';
        _barSlider.value = _value;
    }

    private IEnumerator ChangeHealth(float targetHealth, float maxHealth)
    {
        while (_value != targetHealth && _value <= maxHealth)
        {
            _value = Mathf.MoveTowards(_value, targetHealth, _healthChangeSpeed);
            PrintValue();
            yield return null;
        }
    }
}
