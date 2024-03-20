using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : Platform
{
    private BoxCollider2D _colider;

    [SerializeField] 
    MainCharacterOfPlatform _characterColor;
    [SerializeField]
    private float _timeOfOnColider = 3f;

    private float _timer = 0;
    private bool _isCollision;

    private enum MainCharacterOfPlatform
    {
        Blue,
        Pink
    }

    void Start()
    {
        _colider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(_isCollision)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeOfOnColider) OnColider();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_characterColor == MainCharacterOfPlatform.Blue)
        {
            if(collision.gameObject.TryGetComponent(out PinkCharacter pinkCharacter))
            {
                _colider.enabled = false;
                _isCollision = true;
            }
        }

        if (_characterColor == MainCharacterOfPlatform.Pink)
        {
            if (collision.gameObject.TryGetComponent(out BlueCharacter blueCharacter))
            {
                _colider.enabled = false;
                _isCollision = true;
            }
        }

        if(collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            OnColider();
        }
    }

    private void OnColider()
    {
        _colider.enabled = true;
        _timer = 0;
        _isCollision = false;
    }
}
