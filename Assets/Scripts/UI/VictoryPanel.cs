using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShowVictoryPanel()
    {
        Debug.Log("Victory");
        _pauseButton.gameObject.SetActive(false);
        _animator.Play("ShowVictoryPanel");
    }
}
