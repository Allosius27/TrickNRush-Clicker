using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFxInstantiate : MonoBehaviour
{
    #region UnityInspector

    [SerializeField] private SpecialAbility specialAbility;

    #endregion

    #region Behaviour

    private void Start()
    {
        if(specialAbility is KitschieAbilitie)
        {
            KitschieAbilitie kitschieAbilitie = (KitschieAbilitie)specialAbility;
            float _bonusDuration = kitschieAbilitie.BonusDuration + kitschieAbilitie.currentBonusDurationUpgrade;
            Debug.Log(_bonusDuration);
            Destroy(gameObject, _bonusDuration);
        }
        else if(specialAbility is MagHoulAbilitie)
        {
            MagHoulAbilitie magHoulAbilitie = (MagHoulAbilitie)specialAbility;
            float _bonusDuration = magHoulAbilitie.BonusDuration + magHoulAbilitie.currentBonusDurationUpgrade;
            Debug.Log(_bonusDuration);
            Destroy(gameObject, _bonusDuration);
        }
    }

    #endregion
}
