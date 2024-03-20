using UnityEngine;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot _normalSnapshot;
    [SerializeField] private AudioMixerSnapshot _pauseSnapshot;

    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ShowPausePanel()
    {
        _animator.Play("ShowPausePanel");
        _pauseSnapshot.TransitionTo(0.5f);
        Time.timeScale = 0;
    }

    public void HidePausePanel()
    {
        _animator.Play("HidePausePanel");
        _normalSnapshot.TransitionTo(0.5f);
        Time.timeScale = 1;
    }
}
