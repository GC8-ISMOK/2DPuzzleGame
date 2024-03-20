using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IPlayerKillable 
{
    public UnityEvent OnPlayerDied { get; }
}
