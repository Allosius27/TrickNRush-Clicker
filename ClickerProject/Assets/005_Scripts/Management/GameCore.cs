using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCore : AllosiusDev.Singleton<GameCore>
{
    #region Fields

    #endregion

    #region Properties

    public GameObject PrefabHitPoint => prefabHitPoint;
    public GameObject PrefabBaseFxHit => prefabBaseFxHit;

    public AllosiusDev.FeedbacksData FxCandiesFeedback => fxCandiesFeedback;
    public AllosiusDev.FeedbacksData FxGoldFeedback => fxGoldFeedback;

    #endregion

    #region UnityInspector

    [SerializeField] private GameObject prefabHitPoint;
    [SerializeField] private GameObject prefabBaseFxHit;

    [SerializeField] private AllosiusDev.FeedbacksData fxCandiesFeedback;
    [SerializeField] private AllosiusDev.FeedbacksData fxGoldFeedback;

    [Space]

    [SerializeField] private List<EnemyData> typesEnemies = new List<EnemyData>();

    #endregion

    #region Behaviour

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        NewMonster();

        /*for (var i = 0; i < 1000; i++)
        {
            int randomNumber = IntUtil.Random(1, 100);
            Debug.Log(randomNumber);
        }*/
    }

    public void InstantiateBaseFxHit(Vector3 _target)
    {
        GameObject _fxHit = Instantiate(prefabBaseFxHit, _target, Quaternion.identity);
    }

    public void NewMonster()
    {
        int _currentMonster = 0;
        if (typesEnemies.Count > 1)
        {
            while (typesEnemies[_currentMonster] == EntitiesManager.Instance.Enemy.currentEnemyData)
            {
                //_currentMonster = Random.Range(0, typesEnemies.Count);
                _currentMonster = IntUtil.Random(0, typesEnemies.Count);
            }

            typesEnemies = IntUtil.RandomizeList(typesEnemies);
        }

        EntitiesManager.Instance.Enemy.SetEnemy(typesEnemies[_currentMonster]);
    }

    
    #endregion
}
