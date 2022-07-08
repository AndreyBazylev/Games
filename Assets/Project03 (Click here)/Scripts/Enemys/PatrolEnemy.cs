using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isEnemyPatroling;

    private SpriteRenderer _sriteRenderer;
    private Coroutine _targetCoruntine;

    private void Start()
    {
        _sriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeDirection());
    }

    private IEnumerator ChangeDirection()
    {
        while (_isEnemyPatroling)
        {
            for (int index = 1; index < _points.Length - 1; index++)
            {
                if (transform.position.x - _points[index].position.x > 0)
                {
                    _sriteRenderer.flipX = true;
                }

                else
                {
                    _sriteRenderer.flipX = false;
                }

                Debug.Log("UwU");

                if (_targetCoruntine != null)
                {
                    StopCoroutine(_targetCoruntine);
                }
                
                _targetCoruntine = StartCoroutine(GoToTarget(_points[index]));
                
                yield return null;
            }
        }
    }

    private IEnumerator GoToTarget(Transform target)
    {
        while (transform.position != target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
