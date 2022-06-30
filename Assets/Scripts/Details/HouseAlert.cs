using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HouseAlert : MonoBehaviour
{
    [SerializeField] AudioClip _alertSound;
    [SerializeField] float _alertSpeed;

    private AudioSource _audioSource;

    private float _maxStrenght;
    private float _minStrenght;
    private float _audioStrenght;

    private bool _soundVolumeIsIncrease = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _minStrenght = 0.3f;
        _maxStrenght = 0.8f;
        _audioStrenght = _minStrenght;
    }

    public void StartAlert()
    {        
        _audioSource.volume = _audioStrenght;

        if (_soundVolumeIsIncrease)
        {
            _audioStrenght = Mathf.MoveTowards(_audioStrenght, _maxStrenght, _alertSpeed * Time.deltaTime);
        }

        else
        {
            _audioStrenght = Mathf.MoveTowards(_audioStrenght, _minStrenght, _alertSpeed * Time.deltaTime);
        }
        
        if (_audioStrenght <= _minStrenght)
        {
            _soundVolumeIsIncrease = true;
        }

        else if (_audioStrenght >= _maxStrenght)
        {
            _soundVolumeIsIncrease = false;
        }
    }
}
