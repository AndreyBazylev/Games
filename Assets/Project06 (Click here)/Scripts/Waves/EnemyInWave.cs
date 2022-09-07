using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInWave : MonoBehaviour
{
    [SerializeField] public WaveEnemy EnemyPrefab { get; private set; }
    [SerializeField] public int EnemyCount { get; private set; }
    public void DcreaseCount()
    {
        EnemyCount--;
    }
}
