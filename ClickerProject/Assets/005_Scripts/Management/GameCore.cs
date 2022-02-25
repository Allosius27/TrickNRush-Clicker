using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : AllosiusDev.Singleton<GameCore>
{
    #region Fields

    private int _currentMonster;

    private int currentDamagePerClick = 1;

    private int currentGold;
    private int currentCandies;

    #endregion

    #region Properties

    public int CurrentGold => currentGold;
    public int CurrentCandies => currentCandies;

    #endregion

    #region UnityInspector

    [SerializeField] private GameObject prefabHitPoint;

    [Space]

    [SerializeField] private Enemy enemy;

    [Space]

    [SerializeField] private List<EnemyData> typesEnemies = new List<EnemyData>();

    [Space]

    [SerializeField] private GameObject goldUi;
    [SerializeField] private GameObject candiesUi;

    [Space]

    [SerializeField] private PlayerData playerData;

    #endregion

    #region Behaviour

    #endregion
}
