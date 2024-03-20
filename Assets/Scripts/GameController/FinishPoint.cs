using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private CharacterColor _targetCharacter;

    [HideInInspector] public UnityEvent characterComedOnFinish;
    [HideInInspector] public UnityEvent characterGoedOutFinish;

    private bool _isFinished = false;

    private enum CharacterColor
    {
        Pink,
        Blue
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PinkCharacter pinkCharacter) && _targetCharacter == CharacterColor.Pink && !_isFinished)
        {
            characterComedOnFinish?.Invoke();
            _isFinished = true;
        }

        if (collision.gameObject.TryGetComponent(out BlueCharacter blueCharacter) && _targetCharacter == CharacterColor.Blue && !_isFinished)
        {
            characterComedOnFinish?.Invoke();
            _isFinished = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PinkCharacter pinkCharacter) && _targetCharacter == CharacterColor.Pink && _isFinished)
        {
            characterGoedOutFinish?.Invoke();
            _isFinished = false;
        }

        if (collision.gameObject.TryGetComponent(out BlueCharacter blueCharacter) && _targetCharacter == CharacterColor.Blue && _isFinished)
        {
            characterGoedOutFinish?.Invoke();
            _isFinished = false;
        }
    }
}
