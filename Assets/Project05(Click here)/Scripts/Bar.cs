using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _barSlider;
    [SerializeField] private Text _barText;

    private float _value;

    public void SetValue(float newValue)
    {
        _value = newValue;
        PrintValue();
    }

    private void PrintValue()
    {
        _barText.text = Convert.ToString(Convert.ToInt32(_value)) + '%';
        _barSlider.value = _value;
    }

    
}
