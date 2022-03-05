using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : AllosiusDev.Singleton<GUIManager>
{
    #region Fields

    private GameObject characterUpgradeInstance;
    private GameObject characterAbilityUpgradeInstance;

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

    [SerializeField] private GameObject prefabUpgradeUi;
    [SerializeField] private GameObject prefabAbilityUpgradeUi;
    [SerializeField] private Transform parentCharactersUpgrades;

    #endregion

    #region Behaviour

    private void Start()
    {
        ChangeCharacterSelected(charactersPortraits[0]);

        CreateCharacterUpgradeInstance();
        CreateCharacterAbilityUpdradeInstance();

        SetCharacterUpgradeUI();
        SetCharacterAbilityUpgradeUI();

        UpdateCandiesUI();
        UpdateGoldUI();
    }

    private void CreateCharacterUpgradeInstance()
    {
        characterUpgradeInstance = Instantiate(prefabUpgradeUi, parentCharactersUpgrades, false);
        characterUpgradeInstance.transform.localPosition = Vector3.zero;
    }

    private void CreateCharacterAbilityUpdradeInstance()
    {
        characterAbilityUpgradeInstance = Instantiate(prefabAbilityUpgradeUi, parentCharactersUpgrades, false);
        characterAbilityUpgradeInstance.transform.localPosition = Vector3.zero;
    }

    public void SetCharacterUpgradeUI()
    {
        if (characterUpgradeInstance != null)
        {
            
            characterUpgradeInstance.GetComponent<CharacterUpgradeUI>().Initialize(PlayersController.Instance.currentCharacterSelected.characterData.characterUpgrade, 
                PlayersController.Instance.currentCharacterSelected);
        }
        else
        {
            Debug.LogWarning("upgradeInstance is null");
        }
    }

    public void SetCharacterAbilityUpgradeUI()
    {
        if (characterAbilityUpgradeInstance != null)
        {
            characterAbilityUpgradeInstance.GetComponent<CharacterAbilityUpgradeUI>().Initialize(PlayersController.Instance.currentCharacterSelected.characterData.abilityUpgrade,
                PlayersController.Instance.currentCharacterSelected);
        }
        else
        {
            Debug.LogWarning("upgradeInstance is null");
        }
    }

    public void ChangeCharacterSelected(CharacterPortrait character)
    {
        for (int i = 0; i < charactersPortraits.Count; i++)
        {
            charactersPortraits[i].SelectCharacter(false);
        }

        character.SelectCharacter(true);
        currentSelectedCharacterPortrait.sprite = character.characterData.selectedPortraitSprite;
        PlayersController.Instance.currentCharacterSelected = character;

        SetCharacterUpgradeUI();
        SetCharacterAbilityUpgradeUI();
    }

    public void UpdateGoldUI()
    {
        goldUi.GetComponent<TextMeshProUGUI>().text = PlayersController.Instance.CurrentGold.ToString();
    }

    public void UpdateCandiesUI()
    {
        candiesUi.GetComponent<TextMeshProUGUI>().text = PlayersController.Instance.CurrentCandies.ToString();
    }

    #endregion
}
