using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : AllosiusDev.Singleton<GUIManager>
{
    #region Fields

    private GameObject upgradeInstance;

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

    //[SerializeField] private List<CharacterUpgradeData> characterUpgrades = new List<CharacterUpgradeData>();
    [SerializeField] private GameObject prefabUpgradeUi;
    [SerializeField] private Transform parentCharactersUpgrades;

    #endregion

    #region Behaviour

    private void Start()
    {
        ChangeCharacterSelected(charactersPortraits[0]);

        CreateCharacterUpgradeInstance();
        SetCharacterUpgradeUI();

        UpdateCandiesUI();
        UpdateGoldUI();
    }

    private void CreateCharacterUpgradeInstance()
    {
        upgradeInstance = Instantiate(prefabUpgradeUi, parentCharactersUpgrades, false);
        upgradeInstance.transform.localPosition = Vector3.zero;
    }

    public void SetCharacterUpgradeUI()
    {
        if (upgradeInstance != null)
        {
            
            upgradeInstance.GetComponent<CharacterUpgradeUI>().Initialize(PlayersController.Instance.currentCharacterSelected.characterData.characterUpgrade, 
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
