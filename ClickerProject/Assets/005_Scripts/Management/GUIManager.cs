using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : AllosiusDev.Singleton<GUIManager>
{
    #region Fields

    

    #endregion

    #region Properties

    public GameObject GoldUI => goldUi;
    public GameObject CandiesUI => candiesUi;

    public List<CharacterPortrait> CharactersPortraits => charactersPortraits;

    #endregion

    #region UnityInspector

    [SerializeField] private GameObject goldUi;
    [SerializeField] private GameObject candiesUi;

    [Space]

    [SerializeField] private Image currentSelectedCharacterPortrait;

    [SerializeField] private List<CharacterPortrait> charactersPortraits = new List<CharacterPortrait>();

    [Space]

    [SerializeField] private List<CharacterUpgradeData> characterUpgrades = new List<CharacterUpgradeData>();
    [SerializeField] private GameObject prefabUpgradeUi;
    [SerializeField] private Transform parentCharactersUpgrades;

    #endregion

    #region Behaviour

    private void Start()
    {
        ChangeCharacterSelected(charactersPortraits[0]);

        for(int i = 0; i < characterUpgrades.Count; i++)
        {
            GameObject upgradeInstance = Instantiate(prefabUpgradeUi, parentCharactersUpgrades, false);
            upgradeInstance.transform.localPosition = Vector3.zero;
            upgradeInstance.GetComponent<CharacterUpgradeUI>().Initialize(characterUpgrades[i], charactersPortraits[i]);
        }
    }

    public void ChangeCharacterSelected(CharacterPortrait character)
    {
        for (int i = 0; i < charactersPortraits.Count; i++)
        {
            charactersPortraits[i].SelectCharacter(false);
        }

        character.SelectCharacter(true);
        currentSelectedCharacterPortrait.sprite = character.characterData.portraitSprite;
        PlayersController.Instance.currentCharacterSelected = character;
    }

    #endregion
}
