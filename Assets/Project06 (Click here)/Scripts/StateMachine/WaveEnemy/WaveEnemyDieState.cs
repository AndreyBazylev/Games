using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyDieState : State
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private AudioClip _deathSound;

    private const string IsDead = "IsDead";
    private const string Delete = "Delete";

    private void OnEnable()
    {
        Animator.SetBool(IsDead, true);
        _deathSound = GetComponent<EnemyHealth>().DeathSound;
        GetComponent<AudioSource>().PlayOneShot(_deathSound);
        _playerWallet.IcreaseMoney(gameObject.GetComponent<WaveEnemy>().PriceForDead);
    }

    private void Update()
    {
        var animatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(Delete))
        {
            Destroy(gameObject);
        }
    }

    public void SetWallet(Wallet wallet)
    {
        _playerWallet = wallet;
    }
}
