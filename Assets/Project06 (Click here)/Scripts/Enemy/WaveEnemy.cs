using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(WaveEnemyStateMachine))]

public class WaveEnemy : MonoBehaviour
{
    [SerializeField] private AudioClip _simpleDeathSound;

    [SerializeField] public float Damage { get; private set; }
    [SerializeField] public int PriceForDead { get; private set; }
    [SerializeField] public Vector3 Offset { get; private set; }    
    [SerializeField] public EnemyHealth Health { get; private set; }
    [SerializeField] public WaveEnemyStateMachine StateMachine { get; private set; }
}
