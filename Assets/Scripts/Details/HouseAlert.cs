using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HouseAlert : MonoBehaviour
{
    [SerializeField] private AudioClip _alertSound;
    [SerializeField] private float _alertSpeed;
    [SerializeField] private float _maxStrenght;
    [SerializeField] private float _minStrenght;
    
    private AudioSource _audioSource;

    private float _audioStrenght;
    private float _coruntineDelay;
    
    private bool _isPlayerInHouse = false;
    private bool _soundVolumeIsIncrease = true;

    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _minStrenght = 0.3f;
        _maxStrenght = 0.8f;
        _coruntineDelay = 0.1f;
        _audioStrenght = _minStrenght;
    }

    public void StartAlert()
    {
        if (_isPlayerInHouse)
        {
            StartCoroutine(ChangeAlertVolume());
            _audioSource.Play();
        }  
    }

    public void SpecifyPlayerLocation()
    {
        _isPlayerInHouse = !_isPlayerInHouse;
    }

    public void TurnOffAlert()
    {
        if (_isPlayerInHouse == false)
        {
            StopAllCoroutines();

            while (_audioStrenght > 0)
            {
                _audioStrenght = Mathf.MoveTowards(_audioStrenght, 0, _alertSpeed * Time.deltaTime);
            }
        }
    }

    private IEnumerator ChangeAlertVolume()
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

        StartCoroutine(ChangeAlertVolumeDerection());

        yield return null;
    }

    private IEnumerator ChangeAlertVolumeDerection()
    {
        if (_audioStrenght <= _minStrenght)
        {
            _soundVolumeIsIncrease = true;
        }

        else if (_audioStrenght >= _maxStrenght)
        {
            _soundVolumeIsIncrease = false;
        }

        yield return new WaitForSeconds(_coruntineDelay);
    }
}
