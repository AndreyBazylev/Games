using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private int _enemyCount;

    public int GetEnemyCount()
    {
        return _enemyCount;
    }
}
