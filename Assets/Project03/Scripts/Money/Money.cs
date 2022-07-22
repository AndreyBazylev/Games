using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet result))
        {
            result.IcreaseMoney(1);
            Destroy(gameObject);
        }
    }
}
