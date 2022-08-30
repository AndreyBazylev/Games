using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyDieState : State
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private AudioClip _deathSound;

    private const string IsDead = "IsDead";
    private const string Delete = "Delete";

    private void Start()
    {
        _stateName = "Die";
    }

    private void OnEnable()
    {
        _stateAnimator.SetBool(IsDead, true);
        _deathSound = GetComponent<WaveEnemy>().GetDethSound();
        GetComponent<AudioSource>().PlayOneShot(_deathSound);
        _playerWallet.IcreaseMoney(gameObject.GetComponent<WaveEnemy>().GetPrice());
    }

    private void Update()
    {
        var animatorStateInfo = _stateAnimator.GetCurrentAnimatorStateInfo(0);

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
