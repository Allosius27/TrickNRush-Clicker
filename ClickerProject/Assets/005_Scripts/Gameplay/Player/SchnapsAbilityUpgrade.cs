using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SchnapsAbilityUpgrade", menuName = "Clicker/Abilities Upgrades/Schnaps Ability Upgrade")]
public class SchnapsAbilityUpgrade : CharacterAbilityUpgrade
{
    #region Properties

    public float GoldBonusMultiplierUpgrade => goldBonusMultiplierUpgrade;

    #endregion

    #region UnityInspector

    [SerializeField] private float goldBonusMultiplierUpgrade;

    #endregion
}
