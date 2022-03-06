using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterAbilityUpgradeUI : MonoBehaviour
{
    #region Fields

    private CharacterAbilityUpgradeData characterAbilityUpgradeData;
    private CharacterAbilityUpgrade currentCharacterAbilityUpgrade;

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

    [Space]

    [SerializeField] private AllosiusDev.AudioData sfxUseButtonPressed;

    #endregion

    #region Behaviour

    public void Initialize(
        CharacterAbilityUpgradeData _upgrade, CharacterPortrait _character)
    {
        characterAbilityUpgradeData = _upgrade;
        characterPortrait = _character;

        _character.characterData.specialAbility.ResetBonusModifiersUpgrades();

        activeBuyButton.gameObject.SetActive(true);
        inactiveBuyButton.gameObject.SetActive(false);

        SetCurrentCharacterAbilityUpgrade();
    }

    private void SetCurrentCharacterAbilityUpgrade()
    {
        if (characterPortrait.currentCharacterAbilityUpgradeIndex < characterAbilityUpgradeData.listCharacterAbilitiesUpgradesToUnlock.Count)
        {
            currentCharacterAbilityUpgrade = characterAbilityUpgradeData.listCharacterAbilitiesUpgradesToUnlock[characterPortrait.currentCharacterAbilityUpgradeIndex];
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
        attackDescription.text = "Puissance : " + characterPortrait.characterData.specialAbility.DamagePercent + "%";
        characterPortrait.characterData.specialAbility.SetCharacterAbilityUpgrade(currentCharacterAbilityUpgrade);
        powerEffectDescription.text = characterPortrait.characterData.specialAbility.SetDescriptionSpecialEffect();

        Debug.Log(currentCharacterAbilityUpgrade.Cost.ToString());
        textCost.text = currentCharacterAbilityUpgrade.Cost.ToString();

        textLevel.text = "Niveau " + level.ToString();
        

        for (int i = 0; i < upgradesUnlockedIcons.Count; i++)
        {
            if (i < characterPortrait.currentCharacterAbilityUpgradeIndex)
            {
                //Debug.Log("Unlock " + i + " " + characterPortrait.currentCharacterUpgradeIndex);
                upgradesUnlockedIcons[i].sprite = currentCharacterAbilityUpgrade.UpgradeUnlockedUiIcon;
            }
            else
            {
                //Debug.Log("Lock " + i + " " + characterPortrait.currentCharacterUpgradeIndex);
                upgradesUnlockedIcons[i].sprite = currentCharacterAbilityUpgrade.UpgradeLockedUiIcon;
            }
        }
    }

    public void OnClick()
    {
        AllosiusDev.AudioManager.Play(sfxUseButtonPressed.sound);

        if (PlayersController.Instance.CurrentCandies >= currentCharacterAbilityUpgrade.Cost)
        {
            Debug.Log("Buy Upgrade");

            

            PlayersController.Instance.AddCharacterAbilityUpgrade(currentCharacterAbilityUpgrade, characterPortrait);

            characterPortrait.currentCharacterAbilityUpgradeIndex++;
            level++;

            SetCurrentCharacterAbilityUpgrade();
        }
    }

    #endregion
}
