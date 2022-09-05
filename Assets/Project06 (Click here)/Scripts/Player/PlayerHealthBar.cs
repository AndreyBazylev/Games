using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Image _bar;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private Sprite[] _healthValueSprites;
    [SerializeField] private Sprite[] _slimeHealthSprites;

    private int _barValue;

    private int _firstSlimeStage = 35;
    private int _firstSlimeStageNumber = 0;

    private int _secondSlimeStage = 30;
    private int _secondSlimeStageNumber = 1;

    private int _thirdSlimeStage = 20;
    private int _thirdSlimeStageNumber = 2;

    private int _fourthSlimeStage = 10;
    private int _fourthSlimeStageNumber = 3;

    private int _fifthSlimeStageNumber = 4;

    private void Start()
    {
        _playerHealth.Changed += SetHealth;
    }

    private void SetHealth(float _health, float _maxHealth)
    {
        _barValue = (int)_health;
        _bar.sprite = _healthValueSprites[_barValue];

        if (_barValue >= _firstSlimeStage)
        {
            _player.sprite = _slimeHealthSprites[_firstSlimeStageNumber];
        }

        else if (_barValue < _firstSlimeStage && _barValue >= _secondSlimeStage)
        {
            _player.sprite = _slimeHealthSprites[_secondSlimeStageNumber];
        }

        else if (_barValue < _secondSlimeStage && _barValue >= _thirdSlimeStage)
        {
            _player.sprite = _slimeHealthSprites[_thirdSlimeStageNumber];
        }

        else if (_barValue < _thirdSlimeStage && _barValue >= _fourthSlimeStage)
        {
            _player.sprite = _slimeHealthSprites[_fourthSlimeStageNumber];
        }

        else
        {
            _player.sprite = _slimeHealthSprites[_fifthSlimeStageNumber];
        }
    }
}
