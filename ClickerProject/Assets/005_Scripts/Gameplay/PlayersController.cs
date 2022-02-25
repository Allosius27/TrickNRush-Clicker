using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : AllosiusDev.Singleton<PlayersController>
{
    #region Properties

    public CharacterPortrait currentCharacterSelected { get; set; }

    #endregion

    #region UnityInspector

    [SerializeField] private List<CharacterData> characters = new List<CharacterData>();

    #endregion

    #region Behaviour

    private void Start()
    {
        InitCharacters();
    }

    private void InitCharacters()
    {

        for (int i = 0; i < characters.Count; i++)
        {
            GUIManager.Instance.CharactersPortraits[i].InitCharacterData(characters[i]);
        }
    }

    #endregion
}
