using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallButton : MonoBehaviour
{
    [SerializeField] Vector2 _wallOffset;
    [SerializeField] ColorCharacterTrigger _colorCharacter;
    [SerializeField] private Transform _wallTransform;
    [SerializeField] private float _offsetSpeed;

    private Vector2 _targetWallPosition;
    private bool _isOnButton = false;
    private bool _isGoOutButton = false;

    private void FixedUpdate()
    {
        changeWallPosition();
    }

    private void changeWallPosition()
    {
        if (_isOnButton)
        {
            _wallTransform.position = Vector2.Lerp(_wallTransform.position, _targetWallPosition, _offsetSpeed * Time.deltaTime);
        }
        if (_isGoOutButton)
        {
            _wallTransform.position = Vector2.Lerp(_wallTransform.position, _targetWallPosition, _offsetSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PinkCharacter pinkCharacter) && _colorCharacter == ColorCharacterTrigger.pink)
        {
            _targetWallPosition = new Vector2(_wallTransform.position.x + _wallOffset.x, _wallTransform.position.y + _wallOffset.y);
            _isOnButton = true;
            _isGoOutButton = false;
        }

        if (collision.gameObject.TryGetComponent(out BlueCharacter blueCharacter) && _colorCharacter == ColorCharacterTrigger.blue)
        {
            _targetWallPosition = new Vector2(_wallTransform.position.x + _wallOffset.x, _wallTransform.position.y + _wallOffset.y);
            _isOnButton = true;
            _isGoOutButton = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PinkCharacter pinkCharacter) && _colorCharacter == ColorCharacterTrigger.pink)
        {
            _targetWallPosition = new Vector2(_wallTransform.position.x - _wallOffset.x, _wallTransform.position.y - _wallOffset.y);
            _isOnButton = false;
            _isGoOutButton = true;
        }

        if (collision.gameObject.TryGetComponent(out BlueCharacter blueCharacter) && _colorCharacter == ColorCharacterTrigger.blue)
        {
            _targetWallPosition = new Vector2(_wallTransform.position.x - _wallOffset.x, _wallTransform.position.y - _wallOffset.y);
            _isOnButton = false;
            _isGoOutButton = true;
        }
    }

    private enum ColorCharacterTrigger
    {
        pink,
        blue
    }
}
