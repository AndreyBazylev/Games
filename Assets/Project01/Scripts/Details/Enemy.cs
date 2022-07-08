using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _playerDeadSound;
    
    private AudioSource _audioSource;

    private void Start()
    { 
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Movement result))
        {
            Destroy(collision.gameObject);
            _audioSource?.PlayOneShot(_shotSound);
            _audioSource?.PlayOneShot(_playerDeadSound);
        }
    }
}
