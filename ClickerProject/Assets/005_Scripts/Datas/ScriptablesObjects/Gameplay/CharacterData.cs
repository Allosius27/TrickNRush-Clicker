using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Clicker/Character Data")]
public class CharacterData : ScriptableObject
{
    public string characterName;

    public Sprite portraitSprite;

    public float maxPowerValue;

    [Space]

    public SpecialAbility specialAbility;

    [Space]

    public CharacterUpgradeData characterUpgrade;
}
