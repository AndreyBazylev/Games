using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnersArray;
    
    [SerializeField] bool _isEnemySpawningForbidden;
    [SerializeField] GameObject _enemyPrefab;

    private void Start()
    {
        StartCoroutine(ControlingEnemySpawning());
    }

    private IEnumerator ControlingEnemySpawning()
    {
        while (_isEnemySpawningForbidden)
        {
            for (int index = 0; index < _spawnersArray.Length; index++)
            {
                Debug.Log("UwU");
                SpawnEnemy(_spawnersArray[index]);
                yield return new WaitForSeconds(2);
            }
        }
    }

    private void SpawnEnemy(GameObject spawnPosition)
    {
        Instantiate(_enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
    }
}
