using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlertController : MonoBehaviour
{
    [SerializeField] UnityEvent _isPlayerInHouse;
    [SerializeField] UnityEvent _isPlayerInStreet;
}
