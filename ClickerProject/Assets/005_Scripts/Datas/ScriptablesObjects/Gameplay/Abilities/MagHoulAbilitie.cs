using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagHoulAbility", menuName = "Clicker/Abilities/MagHoul Ability")]
public class MagHoulAbilitie : SpecialAbility
{
    #region UnityInspector

    [Range(0, 100)]
    [SerializeField] private int autoClickSpeedBonusPercent;

    [SerializeField] private float bonusDuration = 3.0f;

    #endregion

    #region Behaviour

    public override void ApplySpecialEffect(CharacterPortrait character)
    {
        character.defaultCurrentBonusIntervalAutoClickPercent = character.currentBonusIntervalAutoClickPercent;

        character.currentBonusIntervalAutoClickPercent = autoClickSpeedBonusPercent;
    }

    public override IEnumerator SpecialEffectDuration(CharacterPortrait character)
    {
        yield return new WaitForSeconds(bonusDuration);

        character.currentBonusIntervalAutoClickPercent = character.defaultCurrentBonusIntervalAutoClickPercent;
        
    }

    #endregion

}
