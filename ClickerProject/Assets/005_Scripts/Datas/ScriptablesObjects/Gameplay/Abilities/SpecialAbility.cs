using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialAbility", menuName = "Clicker/Abilities/Special Ability")]
public class SpecialAbility : ScriptableObject
{
    #region Properties

    public int DamagePercent => damagePercent;

    #endregion

    #region UnityInspector
    [Range(0, 100)]
    [SerializeField] private int damagePercent;

    #endregion

    #region Behaviour
    
    public void Attack()
    {
        Enemy enemy = EntitiesManager.Instance.Enemy;
        int damage = GetDamageInflicted(enemy);
        Debug.Log(damage);
        PlayersController.Instance.Hit(damage, enemy, true);
    }

    public int GetDamageInflicted(Enemy _enemy)
    {
        int damage = _enemy.LifeMax * damagePercent / 100;
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

    #endregion
}
