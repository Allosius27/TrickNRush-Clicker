using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Clicker/Character Data")]
public class CharacterData : ScriptableObject
{
    public string characterName;

    [Space]

    public Sprite portraitSprite;
    public Sprite selectedPortraitSprite;

    [Space]

    public float maxPowerValue;

    [Space]

    public SpecialAbility specialAbility;

    [Space]

    public CharacterUpgradeData characterUpgrade;
    public CharacterAbilityUpgradeData abilityUpgrade;
}
