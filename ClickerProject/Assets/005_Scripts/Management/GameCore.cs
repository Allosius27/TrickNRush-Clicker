using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCore : AllosiusDev.Singleton<GameCore>
{
    #region Fields

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

    [SerializeField] private List<EnemyData> typesEnemies = new List<EnemyData>();

    #endregion

    #region Behaviour

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        UpdateCandiesUI();
        UpdateGoldUI();

        NewMonster();

        // Add Upgrade To Buy on Screen
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Hit(PlayersController.Instance.currentCharacterSelected.currentDamagePerClick, enemy);
                }
            }
        }

        
    }

    public void AddCharacterUpgrade(CharacterUpgrade upgrade, CharacterPortrait character)
    {
        Debug.Log("Add Character Upgrade");

        character.currentDamagePerClick += upgrade.AttackPerClickModifier;
        character.currentIntervalAutoClick = upgrade.AutoClickInterval;
        character.currentPowerObtainedPerClick += upgrade.PowerObtainedPerClickModifier;

        ChangeCandiesAmount(-upgrade.Cost);
    }

    public void Hit(int damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);
        GameObject feedback = Instantiate(prefabHitPoint, enemy.LocalCanvas.transform, false);
        feedback.transform.localPosition = Vector3.zero;
        feedback.transform.localPosition = UnityEngine.Random.insideUnitCircle * 250;
        feedback.transform.DOLocalMoveY(500f, 0.8f);
        feedback.GetComponent<TextMeshProUGUI>().text = "- " + damage.ToString();
        feedback.GetComponent<TextMeshProUGUI>().DOFade(0, 0.8f);
        Destroy(feedback, 1f);

        ChangeCandiesAmount((int)(PlayersController.Instance.currentCharacterSelected.currentCandiesObtainedPerClick * PlayersController.Instance.currentCharacterSelected.currentBonusCandiesObtained));
        PlayersController.Instance.currentCharacterSelected.ChangePowerBarValue(PlayersController.Instance.currentCharacterSelected.currentPowerObtainedPerClick);

        if (enemy.IsAlive() == false)
        {
            ChangeGoldAmount((int)(PlayersController.Instance.currentCharacterSelected.currentGoldObtainedPerClick * PlayersController.Instance.currentCharacterSelected.currentBonusGoldObtained));

            NewMonster();
        }
    }

    public void ChangeGoldAmount(int _amount)
    {
        currentGold += _amount;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        GUIManager.Instance.GoldUI.GetComponent<TextMeshProUGUI>().text = currentGold.ToString();
    }

    public void ChangeCandiesAmount(int _amount)
    {
        currentCandies += _amount;
        UpdateCandiesUI();
    }

    private void UpdateCandiesUI()
    {
        GUIManager.Instance.CandiesUI.GetComponent<TextMeshProUGUI>().text = currentCandies.ToString();
    }

    private void NewMonster()
    {
        int _currentMonster = 0;
        if(typesEnemies.Count > 1)
        {
            while(typesEnemies[_currentMonster] == EntitiesManager.Instance.Enemy.currentEnemyData)
            {
                _currentMonster = Random.Range(0, typesEnemies.Count);
            }
        }
        EntitiesManager.Instance.Enemy.SetEnemy(typesEnemies[_currentMonster]);
    }

    #endregion
}
