using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
        _health.Changed.AddListener(RestartHeathCorountine);
    }

    public void RestartHeathCorountine(float health, float maxHealth)
    {
        _barSlider.maxValue = maxHealth;

        if(_currentCorountine != null)
            StopCoroutine(_currentCorountine);

        _currentCorountine = StartCoroutine(ChangeHealth(health, maxHealth));
    }

    private IEnumerator ChangeHealth(float targetHealth, float maxHealth)
    {
        while (_value != targetHealth && _value <= maxHealth)
        {
            _value = Mathf.MoveTowards(_value, targetHealth, _healthChangeSpeed);
            _barSlider.value = _value;
            _barText.text = Convert.ToString(Convert.ToInt32(_value)) + '%';
            yield return null;
        }
    }
}

