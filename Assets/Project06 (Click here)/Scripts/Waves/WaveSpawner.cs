using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WavesController _waveController;
    [SerializeField] private UnityEvent _waveIsDead;

    private int _enemySpawned;
    private WaitForSeconds _wait = new WaitForSeconds(1f);

    private List<WaveEnemy> _currentEnemys = new List<WaveEnemy>();

    private void Update()
    {
        if (_currentEnemys.Count != 0)
        {
            for (int index = 0; index < _currentEnemys.Count; index++)
            {
                if (_currentEnemys[index].GetHealth() <= 0)
                {
                    _currentEnemys.RemoveAt(index);
                }   
            }
        }

        else
        {
            _waveIsDead?.Invoke();
        }
    }

    public void StartWave(Wave wave)
    {
        _enemySpawned = 0;
        StartCoroutine(SpawnEnemy(wave));
    }

    private IEnumerator SpawnEnemy(Wave wave)
    {
        Debug.Log("uwu");

        while (_enemySpawned <= wave.GetEnemyCount())
        {
            WaveEnemy newWaveEnemy = wave.GetRandomEnemy();

            if (newWaveEnemy != null)
            {
                WaveEnemy newEnemy = Instantiate(newWaveEnemy, transform.position + newWaveEnemy.GetOffeset(), transform.rotation);
                _currentEnemys.Add(newEnemy);
            }

            else
            {         
                StopCoroutine(SpawnEnemy(wave));
            }

            yield return _wait;
        }
    }
}
