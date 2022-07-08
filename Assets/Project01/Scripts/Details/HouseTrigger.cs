using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _cameraHousePoint;
    [SerializeField] private GameObject _cameraStreetPoint;
    [SerializeField] private UnityEvent _isPlayerInHouse;

    private bool _isPlayerInStreet = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("*_*");

        if (collision.TryGetComponent(out Movement result))
        {
            if (_isPlayerInStreet)
            {
                _camera.transform.position = _cameraHousePoint.transform.position;
            }
            else
            {
                _camera.transform.position = _cameraStreetPoint.transform.position;
            }

            _isPlayerInStreet = !_isPlayerInStreet;
            _isPlayerInHouse?.Invoke();
        }
    }
}
