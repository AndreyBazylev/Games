using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _barSlider;
    [SerializeField] private Text _barText;
    [SerializeField] private Health _health;
    [SerializeField] private float _healthChangeSpeed;

    private Coroutine _currentCorountine;

    private float _value;

    public void RestartHeathCorountine()
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

    private void PrintValue()
    {
        _barText.text = Convert.ToString(Convert.ToInt32(_value)) + '%';
        _barSlider.value = _value;
    }

    private IEnumerator ChangeHealth()
    {
        while (_value != _health.GetHealthValue())
        {
            _value = Mathf.MoveTowards(_value, _health.GetHealthValue(), _healthChangeSpeed);
            PrintValue();
            yield return null;
        }
    }
}
