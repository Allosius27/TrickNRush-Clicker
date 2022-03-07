using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCore : AllosiusDev.Singleton<GameCore>
{
    #region Fields

    private Vector3 baseHitFxScale = Vector3.one;
    private Vector3 currentHitFxScale = Vector3.one;

    #endregion

    #region Properties

    public GameObject PrefabHitPoint => prefabHitPoint;

    public AllosiusDev.FeedbacksData FxCandiesFeedback => fxCandiesFeedback;
    public AllosiusDev.FeedbacksData FxGoldFeedback => fxGoldFeedback;

    #endregion

    #region UnityInspector

    [SerializeField] private GameObject prefabHitPoint;
    

    [SerializeField] private AllosiusDev.FeedbacksData fxCandiesFeedback;
    [SerializeField] private AllosiusDev.FeedbacksData fxGoldFeedback;

    [Space]

    [SerializeField] private AllosiusDev.AudioData mainThemeMusic;

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

        AllosiusDev.AudioManager.Play(mainThemeMusic.sound);

        /*for (var i = 0; i < 1000; i++)
        {
            int randomNumber = IntUtil.Random(1, 100);
            Debug.Log(randomNumber);
        }*/
    }

    public void InstantiateBaseFxHit(Vector3 _target, float _comboHitValue, float _maxComboHitValue)
    {
        GameObject _fxHit = Instantiate(PlayersController.Instance.currentCharacterSelected.characterData.prefabBaseFxHit, _target, Quaternion.identity);
        if (_comboHitValue >= _maxComboHitValue)
        {
            currentHitFxScale = baseHitFxScale;
        }
        currentHitFxScale = _fxHit.GetComponent<HitFxInstantiate>().SetFxObjectsScale(currentHitFxScale);
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

    public void InstantiateFeedbacksData(AllosiusDev.FeedbacksData feedbacksData, GameObject _owner)
    {
        StartCoroutine(feedbacksData.CoroutineExecute(_owner));
    }
    
    #endregion
}
