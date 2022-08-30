using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] protected AudioClip _tock;

    private Wallet _playerWallet;
    private ParticleSystemRenderer _psr;
    private const string IsFoundPlayer = "IsFoundPlayer";
    private const string IsBoomed = "Destroy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WaveEnemy>())
        {
            collision.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
            collision.GetComponent<WaveEnemy>().TakeDamage(_damage, _tock);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Instantiate(_psr, transform.position, transform.rotation);
            GetComponent<Animator>().SetBool(IsFoundPlayer, true);
        }
    }

    private void Update()
    {
        var animatorStateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(IsBoomed))
        {
            Destroy(gameObject);
        }
    }

    public void SetWallet(Wallet newWallet)
    {
        _playerWallet = newWallet;
    }

    public void SetParticles(ParticleSystemRenderer newPSR)
    {
        _psr = newPSR;
    }
}
