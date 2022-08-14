using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePowerBullet : Bullet
{
    protected override void GiveDamage(GameObject waveEnemy)
    {
        waveEnemy.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
        waveEnemy.GetComponent<WaveEnemy>().TakeDamage(_bulletDamage);
    }
}
