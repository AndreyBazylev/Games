using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private int _priceForDead;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private AudioClip _simpleDeathSound;

    private AudioClip _deathSound;

    public void TakeDamage(float damage, AudioClip tock)
    {
        _health -= damage;

        if (_health > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(tock);
        }

        else 
        {
            GetComponent<AudioSource>().PlayOneShot(_simpleDeathSound);
            SetDeathSound(tock);
        }
    }

    public void SetDeathSound(AudioClip deathSound)
    {
        _deathSound = deathSound;
    }

    public float GetDamage()
    {
        return _damage;
    }

    public float GetHealth()
    {
        return _health;
    }

    public int GetPrice()
    {
        return _priceForDead;
    }

    public Vector3 GetOffeset()
    {
        return _offset;
    }

    public AudioClip GetDethSound()
    {
        return _deathSound;
    }
}
