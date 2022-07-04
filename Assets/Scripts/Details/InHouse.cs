using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InHouse : MonoBehaviour
{
    [SerializeField] UnityEvent _isPlayerInHouse;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isPlayerInHouse?.Invoke();
    }
}
