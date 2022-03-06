using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SchnapsAbility", menuName = "Clicker/Abilities/Schnaps Ability")]
public class SchnapsAbility : SpecialAbility
{
    #region Properties

    public SchnapsAbilityUpgrade schnapsAbilityUpgrade { get; protected set; }

    public float currentGoldBonusMultiplierUpgrade { get; protected set; }

    #endregion

    #region UnityInspector

    [SerializeField] private float goldBonusMultiplier;

    #endregion

    #region Behaviour

    public override void ApplySpecialEffect(CharacterPortrait character)
    {
        Enemy enemy = EntitiesManager.Instance.Enemy;
        int damage = GetDamageInflicted(enemy);

        float _goldBonus = goldBonusMultiplier + currentGoldBonusMultiplierUpgrade;
        int goldObtained = (int)(damage * _goldBonus);

        PlayersController.Instance.ChangeGoldAmount(goldObtained);
    }

    public override void SetCharacterAbilityUpgrade(CharacterAbilityUpgrade characterAbilityUpgrade)
    {
        base.SetCharacterAbilityUpgrade(characterAbilityUpgrade);
        schnapsAbilityUpgrade = (SchnapsAbilityUpgrade)characterAbilityUpgrade;
    }

    public override void ResetBonusModifiersUpgrades()
    {
        base.ResetBonusModifiersUpgrades();

        currentGoldBonusMultiplierUpgrade = 0;
    }

    public override string SetDescriptionSpecialEffect()
    {
        return "Effet Spécial : " + schnapsAbilityUpgrade.PowerDescription + currentGoldBonusMultiplierUpgrade;
    }

    public override void SetBonusModifierUpgrades()
    {
        base.SetBonusModifierUpgrades();

        currentGoldBonusMultiplierUpgrade = schnapsAbilityUpgrade.GoldBonusMultiplierUpgrade;
    }

    #endregion
}
