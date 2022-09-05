using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class RocketLauncherBullet : Bullet
{
    private const string Boom = "IsBoom";
    private const string DestroyRocket = "RocketDestroy";
    private const string RocketIdle = "RocketIdle";

    private Animator _bulletAnimator;
    private Rigidbody2D _bulletRigidbody;

    private AnimatorStateInfo _animatorStateInfo;

    private void Start()
    {
        _bulletAnimator = GetComponent<Animator>();
        _bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void GiveDamage(WaveEnemy waveEnemy)
    {
        waveEnemy.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
        waveEnemy.TakeDamage(_bulletDamage, _tock);
        gameObject.GetComponent<Animator>().SetBool(Boom, true);
        _bulletRigidbody.velocity = new Vector2(0, 0);
        _bulletRigidbody.gravityScale = 0;
    }

    private void Update()
    {
        _animatorStateInfo = _bulletAnimator.GetCurrentAnimatorStateInfo(0);

        if (_animatorStateInfo.IsName(DestroyRocket))
        {
            Destroy(gameObject);
        }

        else if (_animatorStateInfo.IsName(RocketIdle))
        {
            transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
        }
    }
}
