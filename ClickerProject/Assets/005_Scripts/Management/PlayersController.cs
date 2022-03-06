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

    private float comboHitFxTimer = 0.0f;

    #endregion

    #region Properties

    public int CurrentGold => currentGold;
    public int CurrentCandies => currentCandies;

    public CharacterPortrait currentCharacterSelected { get; set; }

    public bool canAttack { get; set; }

    #endregion

    #region UnityInspector

    [SerializeField] private List<CharacterData> characters = new List<CharacterData>();

    [SerializeField] private PlayerData playerData;

    [SerializeField] private float comboHitMaxDuration = 0.5f;

    [Space]

    [SerializeField] private AllosiusDev.AudioData sfxHit;

    #endregion

    #region Behaviour

    private void Start()
    {
        canAttack = true;

        InitCharacters();
    }

    private void Update()
    {
        if(comboHitFxTimer < comboHitMaxDuration)
        {
            comboHitFxTimer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Hit(currentCharacterSelected.currentDamagePerClick, enemy, currentCharacterSelected, true);
                    GameCore.Instance.InstantiateBaseFxHit(new Vector3(world.x, world.y, -1), comboHitFxTimer, comboHitMaxDuration);
                    AllosiusDev.AudioManager.Play(sfxHit.sound);

                    comboHitFxTimer = 0.0f;

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

    public void Hit(int damage, Enemy enemy, CharacterPortrait attackCharacter, bool isCharacterControlled)
    {
        enemy.TakeDamage(damage);

        GameObject feedback = Instantiate(GameCore.Instance.PrefabHitPoint, enemy.LocalCanvas.transform, false);
        feedback.transform.localPosition = Vector3.zero;
        feedback.transform.localPosition = UnityEngine.Random.insideUnitCircle * 200;
        feedback.transform.DOLocalMoveY(500f, 2f);
        feedback.GetComponent<TextMeshProUGUI>().text = "- " + damage.ToString();
        feedback.GetComponent<TextMeshProUGUI>().DOFade(0, 2f);
        Destroy(feedback, 2.1f);

        ChangeCandiesAmount((int)(attackCharacter.currentCandiesObtainedPerClick * attackCharacter.currentBonusCandiesObtained));
        
        attackCharacter.ChangePowerBarValue(attackCharacter.currentPowerObtainedPerClick);

        if (isCharacterControlled)
        {
            enemy.LaunchHitAnimation();

            StartCoroutine(GameCore.Instance.FxCandiesFeedback.CoroutineExecute(enemy.gameObject));

        }

        if (enemy.IsAlive() == false)
        {
            enemy.Death();

            ChangeGoldAmount((int)(currentCharacterSelected.currentGoldObtainedPerClick * currentCharacterSelected.currentBonusGoldObtained));
            StartCoroutine(GameCore.Instance.FxCandiesFeedback.CoroutineExecute(this.gameObject));

            GameCore.Instance.NewMonster();
        }
    }

    public void AddCharacterUpgrade(CharacterUpgrade upgrade, CharacterPortrait character)
    {
        Debug.Log("Add Character Upgrade");

        character.currentDamagePerClick += upgrade.AttackPerClickModifier;
        character.currentIntervalAutoClick = upgrade.AutoClickInterval;
        character.currentPowerObtainedPerClick += upgrade.PowerObtainedPerClickModifier;

        character.autoClickActive = true;

        ChangeCandiesAmount(-upgrade.Cost);
    }

    public void AddCharacterAbilityUpgrade(CharacterAbilityUpgrade upgrade, CharacterPortrait character)
    {
        Debug.Log("Add Character Ability Upgrade");

        character.characterData.specialAbility.SetCharacterAbilityUpgrade(upgrade);
        character.characterData.specialAbility.SetBonusModifierUpgrades();

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

    #region Saving

    #endregion

    #endregion
}
