using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayersController : AllosiusDev.Singleton<PlayersController>
{
    #region Fields

    private int currentGold;
    private int currentCandies;

    #endregion

    #region Properties

    public int CurrentGold => currentGold;
    public int CurrentCandies => currentCandies;

    public CharacterPortrait currentCharacterSelected { get; set; }

    #endregion

    #region UnityInspector

    [SerializeField] private List<CharacterData> characters = new List<CharacterData>();

    [SerializeField] private PlayerData playerData;

    #endregion

    #region Behaviour

    private void Start()
    {
        InitCharacters();
    }

    private void Update()
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
                    Hit(currentCharacterSelected.currentDamagePerClick, enemy, true);
                }
            }
        }
    }

    private void InitCharacters()
    {

        for (int i = 0; i < characters.Count; i++)
        {
            GUIManager.Instance.CharactersPortraits[i].InitCharacterData(characters[i]);
            LoadPlayerData(GUIManager.Instance.CharactersPortraits[i]);
        }
    }

    private void LoadPlayerData(CharacterPortrait character)
    {
        character.currentDamagePerClick = playerData.baseDamagePerClick;
        character.currentPowerObtainedPerClick = playerData.basePowerObtainedPerClick;
        character.currentGoldObtainedPerClick = playerData.baseGoldObtainedPerClick;
        character.currentCandiesObtainedPerClick = playerData.baseCandiesObtainedPerClick;
    }

    public void Hit(int damage, Enemy enemy, bool isCharacterControlled)
    {
        enemy.TakeDamage(damage);
        GameObject feedback = Instantiate(GameCore.Instance.PrefabHitPoint, enemy.LocalCanvas.transform, false);
        feedback.transform.localPosition = Vector3.zero;
        feedback.transform.localPosition = UnityEngine.Random.insideUnitCircle * 250;
        feedback.transform.DOLocalMoveY(500f, 0.8f);
        feedback.GetComponent<TextMeshProUGUI>().text = "- " + damage.ToString();
        feedback.GetComponent<TextMeshProUGUI>().DOFade(0, 0.8f);
        Destroy(feedback, 1f);

        if (isCharacterControlled)
        {
            ChangeCandiesAmount((int)(currentCharacterSelected.currentCandiesObtainedPerClick * currentCharacterSelected.currentBonusCandiesObtained));
            currentCharacterSelected.ChangePowerBarValue(currentCharacterSelected.currentPowerObtainedPerClick);
        }

        if (enemy.IsAlive() == false)
        {
            ChangeGoldAmount((int)(currentCharacterSelected.currentGoldObtainedPerClick * currentCharacterSelected.currentBonusGoldObtained));

            GameCore.Instance.NewMonster();
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

    public void ChangeGoldAmount(int _amount)
    {
        currentGold += _amount;
        GUIManager.Instance.UpdateGoldUI();
    }

    public void ChangeCandiesAmount(int _amount)
    {
        currentCandies += _amount;
        GUIManager.Instance.UpdateCandiesUI();
    }

    #endregion
}
