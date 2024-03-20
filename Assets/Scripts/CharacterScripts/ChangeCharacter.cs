using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private List<Character> _characters;

    [HideInInspector] public UnityAction<Character> characterChanged;

    public int CharactersCount { get { return _characters.Count; } }

    private void Awake()
    {
        _characters.Add(FindObjectOfType<BlueCharacter>().GetComponent<Character>());
        _characters.Add(FindObjectOfType<PinkCharacter>().GetComponent<Character>());
        _characters[0].GetComponent<Character>().enabled = true;
        for (int i = 1; i < _characters.Count; i++)
        {
            _characters[i].GetComponent<Character>().enabled = false;
        }
    }

    public void Start()
    {
        characterChanged.Invoke(_characters[0]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Change();
        }
    }

    private void Change()
    {
        _characters[0].GetComponent<Character>().enabled = false;
        _characters[1].GetComponent<Character>().enabled = true;

        Character lastCharacter = _characters[0];

        for (int i = 1; i < _characters.Count; i++)
        {
            _characters[i - 1] = _characters[i];
        }
        _characters[_characters.Count - 1] = lastCharacter;
        characterChanged?.Invoke(_characters[0]);
    }
}
