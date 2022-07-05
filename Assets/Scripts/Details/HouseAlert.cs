using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HouseAlert : MonoBehaviour
{
    [SerializeField] private AudioClip _alertSound;
    [SerializeField] private float _alertSpeed;
    [SerializeField] private float _maxStrenght = 0.3f;
    [SerializeField] private float _minStrenght = 0.8f;

    private const string ChangeAlertVolumeDerectionCoruntine = "ChangeAlertVolumeDerection";
    
    private AudioSource _audioSource;

    private float _audioStrenght;

    private bool _isPlayerinHouse = false;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioStrenght = _minStrenght;
    }

    private void Update()
    {
        if (_isPlayerinHouse)
        {
            _audioSource.Play(); 
            
            if (_audioStrenght < 8)
            {
                StartCoroutine(ChangeAlertVolume(_maxStrenght));
            }

            else
            {
                StartCoroutine(ChangeAlertVolume(_minStrenght));
            }
        }

        else
        {
            StartCoroutine(ChangeAlertVolume(0));
        }
    }

    public void SpecifyPlayerLocation()
    {
        _isPlayerinHouse = !_isPlayerinHouse; 
    }

    private IEnumerator ChangeAlertVolume(float target)
    {        
        _audioSource.volume = _audioStrenght;

        _audioStrenght = Mathf.MoveTowards(_audioStrenght, target, _alertSpeed * Time.deltaTime);

        yield return null;
    }
}
