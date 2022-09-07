using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePowerBullet : Bullet
{
    protected override void GiveDamage(WaveEnemy waveEnemy)
    {
        waveEnemy.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
        waveEnemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(_bulletDamage, _tock);
    }
}
