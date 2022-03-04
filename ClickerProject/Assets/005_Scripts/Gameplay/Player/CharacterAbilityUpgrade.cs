using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterAbilityUpgrade
{
    #region Properties
    public int Cost => cost;

    public int PowerPercent => powerPercent;

    public Sprite UpgradeUnlockedUiIcon => upgradeUnlockedUiIcon;
    public Sprite UpgradeLockedUiIcon => upgradeLockedUiIcon;


    #endregion

    #region UnityInspector

    [SerializeField] private int cost;

    [SerializeField] private int powerPercent;

    [Space]

    [SerializeField] private Sprite upgradeUnlockedUiIcon;
    [SerializeField] private Sprite upgradeLockedUiIcon;

    #endregion
}
