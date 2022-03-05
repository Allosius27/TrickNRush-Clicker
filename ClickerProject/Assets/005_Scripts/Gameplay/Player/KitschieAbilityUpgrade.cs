using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KitschieAbilityUpgrade", menuName = "Clicker/Abilities Upgrades/Kitschie Ability Upgrade")]
public class KitschieAbilityUpgrade : CharacterAbilityUpgrade
{
    #region Properties
    public float BonusDurationUpgrade => bonusDurationUpgrade;

    public float GoldBonusMultiplierUpgrade => bonusDurationUpgrade;
    public float CandiesBonusMultiplierUpgrade => candiesBonusMultiplierUpgrade;


    #endregion

    #region UnityInspector

    [SerializeField] private float bonusDurationUpgrade;

    [SerializeField] private float goldBonusMultiplierUpgrade;
    [SerializeField] private float candiesBonusMultiplierUpgrade;

    #endregion
}
