using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SchnapsAbility", menuName = "Clicker/Abilities/Schnaps Ability")]
public class SchnapsAbility : SpecialAbility
{
    #region UnityInspector

    [SerializeField] private float goldBonusMultiplier;

    #endregion

    #region Behaviour

    public override void ApplySpecialEffect(CharacterPortrait character)
    {
        Enemy enemy = EntitiesManager.Instance.Enemy;
        int damage = GetDamageInflicted(enemy);
        int goldObtained = (int)(damage * goldBonusMultiplier);

        GameCore.Instance.ChangeGoldAmount(goldObtained);
    }

    #endregion
}
