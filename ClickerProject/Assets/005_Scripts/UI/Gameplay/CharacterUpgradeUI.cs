using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUpgradeUI : MonoBehaviour
{
    #region Fields

    private CharacterUpgradeData characterUpgradeData;
    private CharacterUpgrade currentCharacterUpgrade;
    private int currentCharacterUpgradeIndex;

    private CharacterPortrait characterPortrait;

    private int level = 1;

    #endregion

    #region UnityInspector

    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI attackDescription;
    [SerializeField] private TextMeshProUGUI powerCostDescription;
    [SerializeField] private TextMeshProUGUI textCost;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private Transform upgradesUnlockedParent;

    [Space]

    [SerializeField] private Button activeBuyButton;
    [SerializeField] private Button inactiveBuyButton;

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
        if (currentCharacterUpgradeIndex < characterUpgradeData.ListCharacterUpgradesToUnlock.Count)
        {
            currentCharacterUpgrade = characterUpgradeData.ListCharacterUpgradesToUnlock[currentCharacterUpgradeIndex];
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
        powerCostDescription.text = "Coût Compétence Rush : " + characterPortrait.MaxPowerValue;

        textCost.text = currentCharacterUpgrade.Cost.ToString();

        textLevel.text = "Niveau " + level.ToString();
    }

    public void OnClick()
    {
        if(GameCore.Instance.CurrentCandies >= currentCharacterUpgrade.Cost)
        {
            Debug.Log("Buy Upgrade");

            GameCore.Instance.AddCharacterUpgrade(currentCharacterUpgrade, characterPortrait);

            currentCharacterUpgradeIndex++;
            level++;

            SetCurrentCharacterUpgrade();
        }
    }

    #endregion
}
