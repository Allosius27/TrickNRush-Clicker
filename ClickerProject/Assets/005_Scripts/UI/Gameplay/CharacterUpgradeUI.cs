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

        portrait.sprite = characterUpgrade.Sprite;
        textName.text = _character.name;
        attackDescription.text = "Attaque : " + _character.currentDamagePerClick;
        powerCostDescription.text = "Coût Compétence Rush : " + _character.MaxPowerValue;
        textCost.text = characterUpgrade.Cost.ToString();
        textLevel.text = "Niveau " + level.ToString();
    }

    #endregion
}
