using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private List<EnemyInWave> _enemys;

    private int _enemysCount;
    private int _enemysTypesCount;

    private void Start()
    {
        foreach (var item in _enemys)
        {
            _enemysCount += item.GetEnemyCount();
        }

        _enemysTypesCount = _enemys.Count;
    }

    public int GetEnemyCount()
    {
        return _enemysCount;
    }

    public WaveEnemy GetRandomEnemy(out bool isSucces)
    {
        int result;
        isSucces = true;
        int tryCount = _enemysCount;
        result = Random.Range(0, _enemysTypesCount);

        while (_enemys[result].GetEnemyCount() == 0 && tryCount > 0)
        {
            tryCount--;
            result = Random.Range(0, _enemysTypesCount);
        }

        if (tryCount > 0)
        {
           _enemys[result].DcreaseCount();
            return _enemys[result].GetPrefab(); 
        }

        else
        {
            isSucces = false;
            return _enemys[0].GetPrefab();
        }
    }
}
