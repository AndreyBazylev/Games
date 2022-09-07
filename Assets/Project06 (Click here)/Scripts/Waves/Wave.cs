using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private List<EnemyInWave> _enemys;

    private int _enemysCount;
    private void Start()
    {
        foreach (var item in _enemys)
        {
            _enemysCount += item.EnemyCount;
        }
    }

    public int GetEnemyCount()
    {
        return _enemysCount;
    }

    public WaveEnemy GetRandomEnemy()
    {
        EnemyInWave result;

        while (_enemysCount > 0)
        {
            result = _enemys[Random.Range(0, _enemys.Count)];

            if (result.EnemyCount > 0)
            {
                _enemysCount--;
                result.DcreaseCount();
                return result.EnemyPrefab;     
            }
        }

        return null;
    }
}
