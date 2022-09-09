﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DroneAttack))]
[RequireComponent(typeof(WaveEnemyGoingState))]
[RequireComponent(typeof(WaveEnemyIdleState))]
[RequireComponent(typeof(WaveEnemyDieState))]
[RequireComponent(typeof(WaveEnemy))]

public class DroneStateMachine : WaveEnemyStateMachine
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            EnemyWentTrigger?.Invoke();
            Attack.enabled = true;
            Attack.StartAttack(collision, Enemy.Damage);
        }
    }
}