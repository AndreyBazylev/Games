using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Wave _wave;

    private int _enemySpawned;
    private WaitForSeconds _wait = new WaitForSeconds(1f);

    private void Start()
    {
        _enemySpawned = 0;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        Debug.Log("uwu");

        while (_enemySpawned <= _wave.GetEnemyCount())
        {
            WaveEnemy newWaveEnemy = _wave.GetRandomEnemy(out bool isSucces);

            if (isSucces)
            {
                Instantiate(newWaveEnemy, transform.position, transform.rotation);
            }

            else
            {
                StopCoroutine(SpawnEnemy());
            }

            yield return _wait;
        }
    }
}
