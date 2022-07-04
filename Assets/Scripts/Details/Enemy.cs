using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _playerDeadSound;
    
    private AudioSource _audioSource;

    private void Start()
    { 
        TryGetComponent(out AudioSource result);
        _audioSource = result;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WalkingObject>())
        {
            Destroy(collision.gameObject);
            _audioSource?.PlayOneShot(_shotSound);
            _audioSource?.PlayOneShot(_playerDeadSound);
        }
    }
}
