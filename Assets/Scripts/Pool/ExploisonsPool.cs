using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploisonsPool: MonoBehaviour
{
    [SerializeField] private Explosion _prefab;
    [SerializeField] private int _count;
    [SerializeField] private bool _autoExpand;

    private PoolMono<Explosion> _pool;

    private void Start()
    {
        _pool = new PoolMono<Explosion>(_prefab, _count, gameObject.transform);
        _pool.autoExpand = _autoExpand;
    }

    private void OnEnable()
    {
        Bullet.bulletDestored.AddListener(BlowUp);
    }

    private void OnDisable()
    {
        Bullet.bulletDestored.RemoveListener(BlowUp);
    }

    private void BlowUp(Vector3 position)
    {
        Explosion explosion = _pool.GetFreeElement();
        explosion.transform.position = position;
    }
}
