using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _barSlider;
    [SerializeField] private Health _health;
    [SerializeField] private float _healthChangeSpeed;

    private Coroutine _currentCorountine;

    private void Start()
    {
        _health.Changed += RestartHeathCorountine;
    }

    public void RestartHeathCorountine(float health, float maxHealth)
    {
        _barSlider.maxValue = maxHealth;

        if(_currentCorountine != null)
            StopCoroutine(_currentCorountine);

        _currentCorountine = StartCoroutine(ChangeHealth(health));
    }

    private IEnumerator ChangeHealth(float targetHealth)
    {
        while (_barSlider.value != targetHealth)
        {
            _barSlider.value = Mathf.MoveTowards(_barSlider.value, targetHealth, _healthChangeSpeed);
            yield return null;
        }
    }
}

