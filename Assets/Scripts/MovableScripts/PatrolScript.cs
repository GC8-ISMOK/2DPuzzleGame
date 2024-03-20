using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;

    private int _currentPoint;

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, _patrolPoints[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _patrolPoints[_currentPoint].position)
        {
            _currentPoint++;

            if (_currentPoint == _patrolPoints.Length)
                _currentPoint = 0;
        }
    }
}
