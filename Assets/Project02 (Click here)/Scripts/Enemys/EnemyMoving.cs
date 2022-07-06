using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
    }
}
