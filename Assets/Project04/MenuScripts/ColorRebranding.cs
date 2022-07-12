using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRebranding : MonoBehaviour
{
    [SerializeField] private Image _panel;
    [SerializeField] private Color _targetColor;

    private float _speed = 0.1f;
    private bool _isIncrease = true;
    private Color _startColor;
    private Coroutine _colorCoruntine;

    private void Start()
    {
        _startColor = _panel.color;
    }

    private void Update()
    {
        if (!_isIncrease)
        {
            if (_colorCoruntine == null)
            {
                _colorCoruntine = StartCoroutine(ChangeColor(_targetColor));
            }

            else
            {
                StopCoroutine(_colorCoruntine);
                _colorCoruntine = StartCoroutine(ChangeColor(_targetColor));
            }
        }

        else
        {
            if (_colorCoruntine == null)
            {
                _colorCoruntine = StartCoroutine(ChangeColor(_startColor));
            }

            else
            {
                StopCoroutine(_colorCoruntine);
                _colorCoruntine = StartCoroutine(ChangeColor(_startColor));
            }
        }
    }

    private IEnumerator ChangeColor(Color target)
    {
        Debug.Log("uwu");
        _isIncrease = !_isIncrease; 

        while (_panel.color != target)
        {
            
            _panel.color = Color.Lerp(_panel.color, _targetColor, _speed);
            yield return null;
        }
    }
}
