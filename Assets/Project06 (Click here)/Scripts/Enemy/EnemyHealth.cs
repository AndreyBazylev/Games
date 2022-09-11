using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(WaveEnemyStateMachine))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float Value { get; private set; }

    [SerializeField] public WaveEnemyStateMachine StateMachine { get; private set; }

    [SerializeField] private AudioClip _simpleDeathSound;

    public AudioClip DeathSound { get; private set; }

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage, AudioClip tock)
    {
        Value -= damage;

        if (Value > 0)
        {
            _audioSource.PlayOneShot(tock);
        }

        else
        {
            _audioSource.PlayOneShot(_simpleDeathSound);
            SetDeathSound(tock);
        }
    }

    private void SetDeathSound(AudioClip deathSound)
    {
        DeathSound = deathSound;
    }

}
