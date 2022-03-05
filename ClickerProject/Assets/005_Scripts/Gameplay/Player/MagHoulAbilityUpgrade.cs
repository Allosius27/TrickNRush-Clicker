using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagHoulAbilityUpgrade", menuName = "Clicker/Abilities Upgrades/MagHoul Ability Upgrade")]
public class MagHoulAbilityUpgrade : CharacterAbilityUpgrade
{
    #region Properties

    public int AutoClickSpeedBonusPercentUpgrade => autoClickSpeedBonusPercentUpgrade;

    public float BonusDurationUpgrade => bonusDurationUpgrade;

    #endregion

    #region UnityInspector

    [SerializeField] private int autoClickSpeedBonusPercentUpgrade;

    [SerializeField] private float bonusDurationUpgrade;

    #endregion
}
