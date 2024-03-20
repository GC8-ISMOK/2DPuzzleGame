using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    [SerializeField] private float _lifeTime;

    private AudioSource _audio;

    [System.Obsolete]
    private void Start()
    {
        _particle.startLifetime = _lifeTime;
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(Activate());
    }

    private void OnDisable()
    {
        StopCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        _particle.Play();

        yield return new WaitForSeconds(_lifeTime);

        Deactivate();
    }

    private void Deactivate()
    {
        _audio.pitch = Random.Range(0.75f, 1.25f);
        _audio.Play();
        gameObject.SetActive(false);
    }
}
