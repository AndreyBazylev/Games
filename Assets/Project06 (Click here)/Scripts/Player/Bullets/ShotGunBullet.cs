using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : Bullet
{
    [SerializeField] private List<Bullet> _bullets;

    private void Start()
    {
        for (int index = 0; index < _bullets.Count; index++)
        {
            _bullets[index].SetWallet(PlayerWallet);
        }
    }

    protected override void GiveDamage(EnemyHealth enemyHealth)
    {
        
    }
}
