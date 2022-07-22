using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Image _bar;
    [SerializeField] private Image _slime;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Sprite[] _slimes;

    private void Update()
    {
        _bar.sprite = _sprites[(int)_playerHealth.GetHealth()];

        if (_playerHealth.GetHealth() >= 40)
        {
            _slime.sprite = _slimes[0];
        }
       
        else if (_playerHealth.GetHealth() < 40 && _playerHealth.GetHealth() > 30)
        {
            _slime.sprite = _slimes[1];
        }

        else if (_playerHealth.GetHealth() < 30 && _playerHealth.GetHealth() > 20)
        {
            _slime.sprite = _slimes[2];
        }

        else if (_playerHealth.GetHealth() < 20 && _playerHealth.GetHealth() > 10)
        {
            _slime.sprite = _slimes[3];
        }

        else if (_playerHealth.GetHealth() < 10)
        {
            _slime.sprite = _slimes[4];
        }
    }
}
