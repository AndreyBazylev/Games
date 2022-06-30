using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip _shotSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Move>())
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<AudioSource>().PlayOneShot(_shotSound);
        }
    }
}
