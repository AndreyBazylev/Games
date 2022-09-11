using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWeapon : Weapon
{
    public override void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (WaitTime * Time.deltaTime > WeaponSpeed)
            {
                _audioSource.PlayOneShot(FireSound);
                Bullet newBullet = Instantiate(Bullet, ShotDirection.position, ShotDirection.transform.rotation);
                newBullet.SetWallet(PlayerWallet);
                WaitTime = 0;
            }
        }
    }
}
