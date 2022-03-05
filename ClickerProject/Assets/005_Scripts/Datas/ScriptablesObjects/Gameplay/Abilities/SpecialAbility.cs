using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialAbility", menuName = "Clicker/Abilities/Special Ability")]
public class SpecialAbility : ScriptableObject
{
    #region Properties

    public CharacterAbilityUpgrade characterAbilityUpgrade { get; protected set; }

    public int currentDamagePercentUpgrade { get; protected set; }

    public int DamagePercent => damagePercent;

    public TimerObjectDuration RushActivationPrefab =>rushActivationPrefab;

    public AllosiusDev.FeedbacksData SpecialFxHitFeedback => specialFxHitFeedback;

    #endregion

    #region UnityInspector
    [Range(0, 100)]
    [SerializeField] private int damagePercent;

    [SerializeField] private TimerObjectDuration rushActivationPrefab;

    [SerializeField] private AllosiusDev.FeedbacksData specialFxHitFeedback;

    #endregion

    #region Behaviour
    
    public void Attack(CharacterPortrait _character)
    {
        Enemy enemy = EntitiesManager.Instance.Enemy;
        int damage = GetDamageInflicted(enemy);
        //Debug.Log(damage);
        PlayersController.Instance.Hit(damage, enemy, _character, true);
    }

    public int GetDamageInflicted(Enemy _enemy)
    {
        int _damagePercent = damagePercent + currentDamagePercentUpgrade;
        int damage = _enemy.LifeMax * _damagePercent / 100;
        return damage;
    }

    public virtual void ApplySpecialEffect(CharacterPortrait character)
    {
        Debug.Log("Use Special Effect");
    }

    public virtual IEnumerator SpecialEffectDuration(CharacterPortrait character)
    {
        Debug.Log("Wait Special Effect Duration");

        yield return null;
    }

    public virtual void SetCharacterAbilityUpgrade(CharacterAbilityUpgrade characterAbilityUpgrade)
    {
        this.characterAbilityUpgrade = characterAbilityUpgrade;
    }

    public virtual void ResetBonusModifiersUpgrades()
    {
        currentDamagePercentUpgrade = 0;
    }

    public virtual string SetDescriptionSpecialEffect()
    {
        return "";
    }

    public virtual void SetBonusModifierUpgrades()
    {
        currentDamagePercentUpgrade = characterAbilityUpgrade.PowerPercent;
    }

    #endregion
}
