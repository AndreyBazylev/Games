using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _offset;
    [SerializeField] protected float _weaponSpeed;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _shotDirection;

    protected Vector3 _difference;
    protected float _rotateZ;
    protected float _waitTime = 0;

    void Update()
    {
        _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _rotateZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _rotateZ + _offset);
        _waitTime++;

        if (Input.GetMouseButtonDown(0))
        {
            if (_waitTime * Time.deltaTime > _weaponSpeed)
            {
                Instantiate(_bullet, _shotDirection.position, _shotDirection.transform.rotation);
                _waitTime = 0;
            }
        }
    }
}
