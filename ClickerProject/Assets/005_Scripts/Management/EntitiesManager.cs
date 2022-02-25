using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesManager : AllosiusDev.Singleton<EntitiesManager>
{
    #region Properties

    public Enemy Enemy => enemy;

    #endregion

    #region UnityInspector

    [SerializeField] private Enemy enemy;

    #endregion
}
