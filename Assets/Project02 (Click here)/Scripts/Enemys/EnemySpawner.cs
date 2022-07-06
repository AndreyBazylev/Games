using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnersArray;
    
    [SerializeField] private bool _isEnemySpawningForbidden;
    [SerializeField] private GameObject _anyEnemyPrefab;

    private readonly WaitForSeconds _wait = new WaitForSeconds(2);

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
                yield return _wait;
            }
        }
    }

    private void SpawnEnemy(GameObject spawnPosition)
    {
        Instantiate(_anyEnemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
    }
}
