using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _offset;
    [SerializeField] protected float _weaponSpeed;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected Transform _shotDirection;
    [SerializeField] protected Wallet _playerWallet;
    [SerializeField] protected AudioClip _fireSound;

    protected float _waitTime = 0;

    private Vector3 _difference;
    private float _rotateZ;
    private void Update()
    {
        _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _rotateZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _rotateZ + _offset);
        _waitTime++;

        Shoot();
    }
    public void SetWallet(Wallet wallet)
    {
        _playerWallet = wallet;
    }

    public virtual void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_waitTime * Time.deltaTime > _weaponSpeed)
            {
                GetComponent<AudioSource>().PlayOneShot(_fireSound);
                Bullet newBullet = Instantiate(_bullet, _shotDirection.position, _shotDirection.transform.rotation);
                newBullet.SetWallet(_playerWallet);
                _waitTime = 0;
            }
        }
    }
}
