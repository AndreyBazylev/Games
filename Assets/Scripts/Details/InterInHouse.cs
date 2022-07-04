using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterInHouse : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _cameraHousePoint;
    [SerializeField] UnityEvent _isPlayerInHouse;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<WalkingObject>() && Input.GetKey(KeyCode.F))
        {
            _camera.transform.position = _cameraHousePoint.transform.position;
            _isPlayerInHouse?.Invoke();
        }
    }
}
