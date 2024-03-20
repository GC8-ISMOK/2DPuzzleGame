using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _damping;
    [SerializeField] private Vector3 _offset;    
    [SerializeField] private Transform _worldCameraPosition;

    private ChangeCharacter _changeCharacter;

    [SerializeField]private Transform _player;
    private Vector3 _cameraTargetPosition;

    private bool _isLeft;
    private bool _isWorldCamera = false;
    private bool _isLive = true; 
    private float _playerDirection;

    private void Awake()
    {
        _changeCharacter = FindObjectOfType<ChangeCharacter>();
        _offset = new Vector3(Mathf.Abs(_offset.x), _offset.y, _offset.z);
    }

    
    void Update()
    {
        CameraMovable();
    }

    private void OnEnable()
    {
        _changeCharacter.characterChanged += FindActiveCharacter;
        GameController._playerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _changeCharacter.characterChanged -= FindActiveCharacter;
        GameController._playerDied -= OnPlayerDied;
    }

    private void CameraMovable()
    {
        if(!_isLive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.V)) 
            _isWorldCamera = !_isWorldCamera;

        if (!_isWorldCamera)
        {
            _playerDirection = Input.GetAxisRaw("Horizontal");

            if (_playerDirection < 0) _isLeft = true;
            if (_playerDirection > 0) _isLeft = false;

            if (!_isLeft)
            {
                _cameraTargetPosition = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, _player.position.z + _offset.z);
            }
            else
            {
                _cameraTargetPosition = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, _player.position.z + _offset.z);
            }
            transform.position = Vector3.Lerp(transform.position, _cameraTargetPosition, _damping * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _worldCameraPosition.position, _damping * Time.deltaTime);
        }
    }

    private void FindActiveCharacter(Character character)
    {
        _player = character.transform;
        _isLeft = false;
    }

    private void OnPlayerDied()
    {
        _isLive = false;
    }
}
