using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesBaker : MonoBehaviour
{
    [SerializeField] private Transform _backPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DroneStateMachine>())
        {
            collision.transform.position = _backPoint.transform.position;
        }
    }
}
