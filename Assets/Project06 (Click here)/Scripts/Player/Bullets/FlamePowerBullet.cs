using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePowerBullet : Bullet
{
    protected override void GiveDamage(WaveEnemy enemy)
    {
        enemy.StateMachine.SetWallet(PlayerWallet);
        enemy.Health.TakeDamage(BulletDamage, Tock);
    }
}
