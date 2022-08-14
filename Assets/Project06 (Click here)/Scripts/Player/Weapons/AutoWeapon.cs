using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWeapon : Weapon
{
    public override void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (_waitTime * Time.deltaTime > _weaponSpeed)
            {
                Bullet newBullet = Instantiate(_bullet, _shotDirection.position, _shotDirection.transform.rotation);
                newBullet.SetWallet(_playerWallet);
                _waitTime = 0;
            }
        }
    }
}
