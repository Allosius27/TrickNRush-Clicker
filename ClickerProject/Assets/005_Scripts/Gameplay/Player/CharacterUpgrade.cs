using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterUpgrade
{
    #region Properties
    public int Cost => cost;

    public int AttackPerClickModifier => attackPerClickModifier;
    public float AutoClickInterval => autoClickInterval;
    public int PowerObtainedPerClickModifier => powerObtainedPerClickModifier;

    public Sprite UpgradeUnlockedUiIcon => upgradeUnlockedUiIcon;
    public Sprite UpgradeLockedUiIcon => upgradeLockedUiIcon;


    #endregion

    #region UnityInspector

    [SerializeField] private int cost;

    [SerializeField] private int attackPerClickModifier;
    [SerializeField] private float autoClickInterval;
    [SerializeField] private int powerObtainedPerClickModifier;

    [Space]

    [SerializeField] private Sprite upgradeUnlockedUiIcon;
    [SerializeField] private Sprite upgradeLockedUiIcon;

    #endregion
}