using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterUpgradeData", menuName = "Clicker/Character Upgrade Data")]
public class CharacterUpgradeData : ScriptableObject
{
    #region Properties

    public List<CharacterUpgrade> ListCharacterUpgradesToUnlock => listCharacterUpgradesToUnlock;

    #endregion

    #region UnityInspector

    [SerializeField] private List<CharacterUpgrade> listCharacterUpgradesToUnlock = new List<CharacterUpgrade>();

    #endregion
}
