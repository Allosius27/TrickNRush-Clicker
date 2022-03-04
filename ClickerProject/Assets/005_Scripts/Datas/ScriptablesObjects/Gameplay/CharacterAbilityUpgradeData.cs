using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAbilityUpgradeData", menuName = "Clicker/Character Ability Upgrade Data")]
public class CharacterAbilityUpgradeData : ScriptableObject
{
    #region Properties

    public List<CharacterAbilityUpgrade> ListCharacterAbilitiesUpgradesToUnlock => listCharacterAbilitiesUpgradesToUnlock;

    #endregion

    #region UnityInspector

    [SerializeField] private List<CharacterAbilityUpgrade> listCharacterAbilitiesUpgradesToUnlock = new List<CharacterAbilityUpgrade>();

    #endregion
}
