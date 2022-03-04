using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterAbilityUpgradeUI : MonoBehaviour
{
    #region Fields

    private CharacterUpgradeData characterUpgradeData;
    private CharacterUpgrade currentCharacterUpgrade;

    private CharacterPortrait characterPortrait;

    private int level = 1;

    #endregion

    #region UnityInspector

    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI attackDescription;
    [SerializeField] private TextMeshProUGUI powerEffectDescription;
    [SerializeField] private TextMeshProUGUI textCost;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private Transform upgradesUnlockedParent;

    [Space]

    [SerializeField] private Button activeBuyButton;
    [SerializeField] private Button inactiveBuyButton;

    [Space]

    [SerializeField] private List<Image> upgradesUnlockedIcons = new List<Image>();

    #endregion

    #region Behaviour

    public void Initialize(CharacterUpgradeData _upgrade, CharacterPortrait _character)
    {
        characterUpgradeData = _upgrade;
        characterPortrait = _character;

        activeBuyButton.gameObject.SetActive(true);
        inactiveBuyButton.gameObject.SetActive(false);

        SetCurrentCharacterUpgrade();
    }

    private void SetCurrentCharacterUpgrade()
    {
        if (characterPortrait.currentCharacterUpgradeIndex < characterUpgradeData.ListCharacterUpgradesToUnlock.Count)
        {
            currentCharacterUpgrade = characterUpgradeData.ListCharacterUpgradesToUnlock[characterPortrait.currentCharacterUpgradeIndex];
        }
        else
        {
            activeBuyButton.gameObject.SetActive(false);
            inactiveBuyButton.gameObject.SetActive(true);
        }

        UpdateCharacterUpgradeUI();
    }

    private void UpdateCharacterUpgradeUI()
    {
        portrait.sprite = characterPortrait.characterData.portraitSprite;
        textName.text = characterPortrait.name;
        attackDescription.text = "Attaque : " + characterPortrait.currentDamagePerClick;
        powerEffectDescription.text = "Co�t Comp�tence Rush : " + characterPortrait.MaxPowerValue;

        textCost.text = currentCharacterUpgrade.Cost.ToString();

        textLevel.text = "Niveau " + level.ToString();

        for (int i = 0; i < upgradesUnlockedIcons.Count; i++)
        {
            if (i < characterPortrait.currentCharacterUpgradeIndex)
            {
                Debug.Log("Unlock " + i + " " + characterPortrait.currentCharacterUpgradeIndex);
                upgradesUnlockedIcons[i].sprite = currentCharacterUpgrade.UpgradeUnlockedUiIcon;
            }
            else
            {
                Debug.Log("Lock " + i + " " + characterPortrait.currentCharacterUpgradeIndex);
                upgradesUnlockedIcons[i].sprite = currentCharacterUpgrade.UpgradeLockedUiIcon;
            }
        }
    }

    public void OnClick()
    {
        if (PlayersController.Instance.CurrentCandies >= currentCharacterUpgrade.Cost)
        {
            Debug.Log("Buy Upgrade");

            PlayersController.Instance.AddCharacterUpgrade(currentCharacterUpgrade, characterPortrait);

            characterPortrait.currentCharacterUpgradeIndex++;
            level++;

            SetCurrentCharacterUpgrade();
        }
    }

    #endregion
}