using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnersArray;
    
    [SerializeField] private bool _isSpawnEnable;
    [SerializeField] private GameObject _enemyPrefab;

    private readonly WaitForSeconds _wait = new WaitForSeconds(2);

    private void Start()
    {
        StartCoroutine(ControlingEnemySpawning());
    }

    private IEnumerator ControlingEnemySpawning()
    {
        while (_isSpawnEnable)
        {
            for (int index = 0; index < _spawnersArray.Length; index++)
            {
                Debug.Log("UwU");
                SpawnEnemy(_spawnersArray[index]);
                yield return _wait;
            }
        }
    }

    private void SpawnEnemy(Transform spawnPosition)
    {
        Instantiate(_enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
    }
}
