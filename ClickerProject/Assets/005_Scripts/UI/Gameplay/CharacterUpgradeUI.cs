using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUpgradeUI : MonoBehaviour
{
    #region Fields

    private CharacterUpgrade characterUpgrade;

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

    #endregion

    #region Behaviour

    public void Initialize(CharacterUpgrade _upgrade, CharacterPortrait _character)
    {
        characterUpgrade = _upgrade;

        characterPortrait = _character;

        portrait.sprite = characterPortrait.characterData.portraitSprite;
        textName.text = characterPortrait.name;
        attackDescription.text = "Attaque : " + characterPortrait.currentDamagePerClick;
        powerCostDescription.text = "Coût Compétence Rush : " + characterPortrait.MaxPowerValue;
        
        textCost.text = characterUpgrade.Cost.ToString();

        textLevel.text = "Niveau " + level.ToString();
    }

    public void OnClick()
    {
        if(GameCore.Instance.CurrentGold >= characterUpgrade.Cost)
        {
            Debug.Log("Buy Upgrade");

            GameCore.Instance.AddCharacterUpgrade(characterUpgrade, characterPortrait);
        }
    }

    #endregion
}
