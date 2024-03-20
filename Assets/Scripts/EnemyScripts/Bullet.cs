using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [Header("BulletSpeed"), SerializeField]
    private float _speed;
    [SerializeField]
    private float _timeToDestroy;

    private Rigidbody2D _rigidbody;

    public static UnityEvent playerShooted = new UnityEvent();
    public static UnityEvent<Vector3> bulletDestored = new UnityEvent<Vector3>();


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Destroy(gameObject, _timeToDestroy);
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = gameObject.transform.InverseTransformVector(Vector2.right) * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ShooterEnemy shooter))
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out PatrolEnemy patrolEnemy))
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out Character character))
        {
            Destroy(collision.gameObject);
            playerShooted?.Invoke();
        }

        bulletDestored?.Invoke(gameObject.transform.position);
        Destroy(gameObject);
    }
}
