using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePowerBullet : Bullet
{
    protected override void GiveDamage(EnemyHealth enemyHealth)
    {
        enemyHealth.GetComponent<WaveEnemyStateMachine>().SetWallet(PlayerWallet);
        enemyHealth.TakeDamage(BulletDamage, Tock);
    }
}
