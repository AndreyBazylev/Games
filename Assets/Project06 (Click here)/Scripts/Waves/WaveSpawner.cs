using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Wave _wave;

    private int _enemySpawned;
    private WaitForSeconds _wait = new WaitForSeconds(2.5f);

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
            _enemySpawned++;
            Instantiate(_enemyPrefab, gameObject.transform);
            yield return _wait;
        }
    }
}
