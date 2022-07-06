using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HouseAlert : MonoBehaviour
{
    [SerializeField] private AudioClip _alertSound;
    [SerializeField] private float _alertSpeed;
    [SerializeField] private float _maxStrenght = 0.8f;
    [SerializeField] private float _minStrenght = 0.3f;
    
    private AudioSource _audioSource;
    private Coroutine _alertVolumeCoruntine;

    private bool _isPlayerinHouse = false;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minStrenght;
    }

    public void ChangeVolumeDirection()
    {
        _isPlayerinHouse = !_isPlayerinHouse;

        if (_isPlayerinHouse)
        {
            _audioSource.Play();

            if (_audioSource.volume < _maxStrenght)
            {
                if (_alertVolumeCoruntine == null)
                {
                    _alertVolumeCoruntine = StartCoroutine(ChangeAlertVolume(_maxStrenght));
                }

                else
                {
                    StopCoroutine(_alertVolumeCoruntine);
                    _alertVolumeCoruntine = StartCoroutine(ChangeAlertVolume(_maxStrenght));
                }
            }
        }

        else
        {
            if (_alertVolumeCoruntine == null)
            {
                _alertVolumeCoruntine = StartCoroutine(ChangeAlertVolume(0));
            }

            else
            {
                StopCoroutine(_alertVolumeCoruntine);
                _alertVolumeCoruntine = StartCoroutine(ChangeAlertVolume(0));
            }
        }
    }

    private IEnumerator ChangeAlertVolume(float target)
    {
        Debug.Log("uwu");

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _alertSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
