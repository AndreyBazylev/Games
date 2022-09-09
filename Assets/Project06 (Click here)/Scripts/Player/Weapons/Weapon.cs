using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float Offset;
    [SerializeField] protected float WeaponSpeed;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected Transform ShotDirection;
    [SerializeField] protected Wallet PlayerWallet;
    [SerializeField] protected AudioClip FireSound;

    protected float WaitTime = 0;

    private Vector3 _difference;
    private float _rotateZ;

    private void Update()
    {
        _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _rotateZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _rotateZ + Offset);
        WaitTime++;

        Shoot();
    }
    public void SetWallet(Wallet wallet)
    {
        PlayerWallet = wallet;
    }

    public virtual void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (WaitTime * Time.deltaTime > WeaponSpeed)
            {
                GetComponent<AudioSource>().PlayOneShot(FireSound);
                Bullet newBullet = Instantiate(Bullet, ShotDirection.position, ShotDirection.transform.rotation);
                newBullet.SetWallet(PlayerWallet);
                WaitTime = 0;
            }
        }
    }
}
