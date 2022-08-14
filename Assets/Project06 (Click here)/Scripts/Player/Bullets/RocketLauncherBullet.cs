using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherBullet : Bullet
{
    private const string Boom = "IsBoom";
    private const string DestroyRocket = "RocketDestroy";
    private const string RocketIdle = "RocketIdle";

    protected override void GiveDamage(GameObject waveEnemy)
    {
        waveEnemy.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
        waveEnemy.GetComponent<WaveEnemy>().TakeDamage(_bulletDamage);
        gameObject.GetComponent<Animator>().SetBool(Boom, true);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void Update()
    {
        var animatorStateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(DestroyRocket))
        {
            Destroy(gameObject);
        }

        else if (animatorStateInfo.IsName(RocketIdle))
        {
            transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
        }
    }
}
