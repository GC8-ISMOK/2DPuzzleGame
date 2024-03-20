using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatrolEnemy : MonoBehaviour, IPlayerKillable
{
    public UnityEvent OnPlayerDied { get; } = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            Destroy(collision.gameObject);
            OnPlayerDied?.Invoke();
        }
    }
}
