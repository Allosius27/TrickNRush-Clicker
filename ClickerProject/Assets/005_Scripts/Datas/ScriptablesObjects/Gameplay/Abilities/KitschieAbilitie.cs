using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KitschieAbility", menuName = "Clicker/Abilities/Kitschie Ability")]
public class KitschieAbilitie : SpecialAbility
{
    #region Properties

    public KitschieAbilityUpgrade kitschieAbilityUpgrade { get; protected set; }

    public float currentCandiesBonusMultiplierUpgrade { get; protected set; }
    public float currentGoldBonusMultiplierUpgrade { get; protected set; }

    public float currentBonusDurationUpgrade { get; protected set; }

    #endregion

    #region UnityInspector

    [SerializeField] private float candiesBonusMultiplier;
    [SerializeField] private float goldBonusMultiplier;

    [SerializeField] private float bonusDuration = 3.0f;

    #endregion

    #region Behaviour

    public override void ApplySpecialEffect(CharacterPortrait character)
    {
        character.defaultCurrentBonusCandiesObtained = character.currentBonusCandiesObtained;
        character.defaultCurrentBonusGoldObtained = character.currentBonusGoldObtained;

        float _candiesBonus = candiesBonusMultiplier + currentCandiesBonusMultiplierUpgrade;
        character.currentBonusCandiesObtained = _candiesBonus;

        float _goldBonus = goldBonusMultiplier + currentGoldBonusMultiplierUpgrade;
        character.currentBonusGoldObtained = _goldBonus;
    }

    public override IEnumerator SpecialEffectDuration(CharacterPortrait character)
    {
        float _bonusDuration = bonusDuration + currentBonusDurationUpgrade;
        yield return new WaitForSeconds(_bonusDuration);

        character.currentBonusCandiesObtained = character.defaultCurrentBonusCandiesObtained;
        character.currentBonusGoldObtained = character.defaultCurrentBonusGoldObtained;
    }

    public override void SetCharacterAbilityUpgrade(CharacterAbilityUpgrade characterAbilityUpgrade)
    {
        base.SetCharacterAbilityUpgrade(characterAbilityUpgrade);
        kitschieAbilityUpgrade = (KitschieAbilityUpgrade)characterAbilityUpgrade;
    }

    public override void ResetBonusModifiersUpgrades()
    {
        base.ResetBonusModifiersUpgrades();

        currentCandiesBonusMultiplierUpgrade = 0;
        currentGoldBonusMultiplierUpgrade = 0;

        currentBonusDurationUpgrade = 0;
    }

    public override string SetDescriptionSpecialEffect()
    {
        return "Special Effect : " + kitschieAbilityUpgrade.PowerDescription + currentCandiesBonusMultiplierUpgrade;
    }

    public override void SetBonusModifierUpgrades()
    {
        base.SetBonusModifierUpgrades();

        currentCandiesBonusMultiplierUpgrade = kitschieAbilityUpgrade.CandiesBonusMultiplierUpgrade;
        currentGoldBonusMultiplierUpgrade = kitschieAbilityUpgrade.GoldBonusMultiplierUpgrade;

        currentBonusDurationUpgrade = kitschieAbilityUpgrade.BonusDurationUpgrade;
    }

    #endregion
}
