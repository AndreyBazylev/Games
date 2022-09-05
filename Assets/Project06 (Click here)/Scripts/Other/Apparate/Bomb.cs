using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] protected AudioClip _tock;

    [SerializeField] private int _damage;

    private const string IsFoundPlayer = "IsFoundPlayer";
    private const string IsBoomed = "Destroy";
    
    private Wallet _playerWallet;
    private ParticleSystemRenderer _psr;
    private Rigidbody2D _bombRigidbody;
    private Animator _bombAnimator;

    private void Start()
    {
        _bombRigidbody = GetComponent<Rigidbody2D>();
        _bombAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WaveEnemy>())
        {
            collision.GetComponent<WaveEnemyStateMachine>().SetWallet(_playerWallet);
            collision.GetComponent<WaveEnemy>().TakeDamage(_damage, _tock);
            _bombRigidbody.gravityScale = 0;
            _bombRigidbody.velocity = new Vector2(0, 0);
            Instantiate(_psr, transform.position, transform.rotation);
            _bombAnimator.SetBool(IsFoundPlayer, true);
        }
    }

    private void Update()
    {
        var animatorStateInfo = _bombAnimator.GetCurrentAnimatorStateInfo(0);

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
