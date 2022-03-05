using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAbilityUpgrade", menuName = "Clicker/Abilities Upgrades/Character Ability Upgrade")]
public class CharacterAbilityUpgrade : ScriptableObject
{
    #region Properties
    public int Cost => cost;

    public int PowerPercent => powerPercent;

    public string PowerDescription => powerDescription;

    public Sprite UpgradeUnlockedUiIcon => upgradeUnlockedUiIcon;
    public Sprite UpgradeLockedUiIcon => upgradeLockedUiIcon;


    #endregion

    #region UnityInspector

    [SerializeField] private int cost;

    [SerializeField] private int powerPercent;

    [SerializeField] private string powerDescription;

    [Space]

    [SerializeField] private Sprite upgradeUnlockedUiIcon;
    [SerializeField] private Sprite upgradeLockedUiIcon;

    #endregion
}
