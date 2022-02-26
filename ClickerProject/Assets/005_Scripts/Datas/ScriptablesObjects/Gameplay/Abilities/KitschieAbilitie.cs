using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KitschieAbility", menuName = "Clicker/Abilities/Kitschie Ability")]
public class KitschieAbilitie : SpecialAbility
{
    #region Properties

    #endregion

    #region UnityInspector

    [SerializeField] private float candiesBonusMultiplier;
    [SerializeField] private float goldBonusMultiplier;

    [SerializeField] private float bonusDuration = 3.0f;

    #endregion

    #region Behaviour

    public override void ApplySpecialEffect(CharacterPortrait character)
    {
        character.defaultCurrentBonusCandiesObtained = character.currentBonusCandiesObtained;
        character.defaultCurrentBonusGoldObtained = character.currentBonusGoldObtained;

        character.currentBonusCandiesObtained = candiesBonusMultiplier;
        character.currentBonusGoldObtained = goldBonusMultiplier;
    }

    public override IEnumerator SpecialEffectDuration(CharacterPortrait character)
    {
        yield return new WaitForSeconds(bonusDuration);

        character.currentBonusCandiesObtained = character.defaultCurrentBonusCandiesObtained;
        character.currentBonusGoldObtained = character.defaultCurrentBonusGoldObtained;
    }

    #endregion
}
