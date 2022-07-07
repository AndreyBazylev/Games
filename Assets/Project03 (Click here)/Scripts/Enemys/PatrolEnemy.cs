using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] bool _isEnemyPatroling;
    [SerializeField] Transform _firstPoint;
    [SerializeField] Transform _secondPoint;

    private SpriteRenderer _sriteRenderer;

    private Coroutine _targetCoruntine;

    private void Start()
    {
        _sriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = _firstPoint.position;

        StartCoroutine(ChangeDirection());
    }

    private IEnumerator ChangeDirection()
    {
        while (_isEnemyPatroling)
        {
            if (transform.position == _firstPoint.position)
            {
                _sriteRenderer.flipX = false;

                if (_targetCoruntine == null)
                {
                    _targetCoruntine = StartCoroutine(GoToTarget(_secondPoint));
                }

                else
                {
                    StopCoroutine(_targetCoruntine);
                    _targetCoruntine = StartCoroutine(GoToTarget(_secondPoint));
                }
            }

            else if (transform.position == _secondPoint.position)
            {
                _sriteRenderer.flipX = true;

                if (_targetCoruntine == null)
                {
                    _targetCoruntine = StartCoroutine(GoToTarget(_firstPoint));
                }

                else
                {
                    StopCoroutine(_targetCoruntine);
                    _targetCoruntine = StartCoroutine(GoToTarget(_firstPoint));
                }
            }

            yield return null;
        }
    }

    private IEnumerator GoToTarget(Transform target)
    {
        Debug.Log("uwu");

        while (transform.position != target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
