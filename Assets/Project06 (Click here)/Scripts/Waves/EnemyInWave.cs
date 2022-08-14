using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInWave : MonoBehaviour
{
    [SerializeField] private WaveEnemy _enemyPrefab;
    [SerializeField] private int _enemyCount;

    public WaveEnemy GetPrefab()
    {
        return _enemyPrefab;
    }

    public int GetEnemyCount()
    {
        return _enemyCount;
    }

    public void DcreaseCount()
    {
        _enemyCount--;
    }
}
