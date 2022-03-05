using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagHoulAbility", menuName = "Clicker/Abilities/MagHoul Ability")]
public class MagHoulAbilitie : SpecialAbility
{
    #region Properties

    public MagHoulAbilityUpgrade magHoulAbilityUpgrade { get; protected set; }

    public int currentAutoClickSpeedBonusPercentUpgrade { get; protected set; }

    public float currentBonusDurationUpgrade { get; protected set; }

    #endregion

    #region UnityInspector

    [Range(0, 100)]
    [SerializeField] private int autoClickSpeedBonusPercent;

    [SerializeField] private float bonusDuration = 3.0f;

    #endregion

    #region Behaviour

    public override void ApplySpecialEffect(CharacterPortrait character)
    {
        character.defaultCurrentBonusIntervalAutoClickPercent = character.currentBonusIntervalAutoClickPercent;

        int _autoClickBonus = autoClickSpeedBonusPercent + currentAutoClickSpeedBonusPercentUpgrade;
        character.currentBonusIntervalAutoClickPercent = _autoClickBonus;
    }

    public override IEnumerator SpecialEffectDuration(CharacterPortrait character)
    {
        float _bonusDuration = bonusDuration + currentBonusDurationUpgrade;
        yield return new WaitForSeconds(_bonusDuration);

        character.currentBonusIntervalAutoClickPercent = character.defaultCurrentBonusIntervalAutoClickPercent;
    }

    public override void SetCharacterAbilityUpgrade(CharacterAbilityUpgrade characterAbilityUpgrade)
    {
        base.SetCharacterAbilityUpgrade(characterAbilityUpgrade);
        magHoulAbilityUpgrade = (MagHoulAbilityUpgrade)characterAbilityUpgrade;
    }

    public override void ResetBonusModifiersUpgrades()
    {
        base.ResetBonusModifiersUpgrades();

        currentAutoClickSpeedBonusPercentUpgrade = 0;
        currentBonusDurationUpgrade = 0;
    }

    public override string SetDescriptionSpecialEffect()
    {
        return "Special Effect : " + magHoulAbilityUpgrade.PowerDescription + currentAutoClickSpeedBonusPercentUpgrade;
    }

    public override void SetBonusModifierUpgrades()
    {
        base.SetBonusModifierUpgrades();

        currentAutoClickSpeedBonusPercentUpgrade = magHoulAbilityUpgrade.AutoClickSpeedBonusPercentUpgrade;
        currentBonusDurationUpgrade = magHoulAbilityUpgrade.BonusDurationUpgrade;
    }

    #endregion

}
