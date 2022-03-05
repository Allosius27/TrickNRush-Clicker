using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAbilityUpgradeData", menuName = "Clicker/Abilities Upgrades/Character Ability Upgrade Data")]
public class CharacterAbilityUpgradeData : ScriptableObject
{
    #region Properties

    #endregion

    #region UnityInspector

    public List<CharacterAbilityUpgrade> listCharacterAbilitiesUpgradesToUnlock = new List<CharacterAbilityUpgrade>();

    #endregion
}
