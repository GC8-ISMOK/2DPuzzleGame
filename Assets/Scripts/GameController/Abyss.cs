using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Abyss : MonoBehaviour, IPlayerKillable
{
    public UnityEvent OnPlayerDied { get; } = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Character character))
        {
            OnPlayerDied?.Invoke();
            Debug.Log("Loser");
        }
    }
}
