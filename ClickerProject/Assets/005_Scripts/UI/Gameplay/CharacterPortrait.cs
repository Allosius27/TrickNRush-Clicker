using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPortrait : MonoBehaviour
{
    #region Fields

    private float powerValue;
    private float maxPowerValue;

    private bool canUsePower;

    private float timerAutoDamage;

    #endregion

    #region Properties

    public CharacterData characterData { get; protected set; }


    public float MaxPowerValue => maxPowerValue;

    public float defaultCurrentBonusCandiesObtained { get; set; }
    public float defaultCurrentBonusGoldObtained { get; set; }

    public int defaultCurrentBonusIntervalAutoClickPercent { get; set; }



    public float currentBonusGoldObtained { get; set; }
    public float currentBonusCandiesObtained { get; set; }

    public int currentBonusIntervalAutoClickPercent { get; set; }



    public int currentDamagePerClick { get; set; }

    public int currentPowerObtainedPerClick { get; set; }

    public int currentGoldObtainedPerClick { get; set; }

    public int currentCandiesObtainedPerClick { get; set; }


    public float currentIntervalAutoClick { get; set; }



    public bool autoClickActive { get; set; }


    public int currentCharacterUpgradeIndex { get; set; }
    public int currentCharacterAbilityUpgradeIndex { get; set; }


    #endregion

    #region UnityInspector

    [SerializeField] private Image portraitImage;

    [Space]

    [SerializeField] private GameObject activeBorder;

    public TextMeshProUGUI levelLabel;

    [Space]

    [SerializeField] private Button buttonUse;
    [SerializeField] private GameObject buttonUseText;
    [SerializeField] private Color buttonUseTextActiveColor;
    [SerializeField] private Color buttonUseTextInactiveColor;

    [Space]

    [SerializeField] private Slider powerBar;

    [Space]

    [SerializeField] private AllosiusDev.AudioData sfxRushActivation;
    [SerializeField] private AllosiusDev.AudioData sfxUseButtonPressed;

    #endregion

    #region Behaviour

    private void Start()
    {
        defaultCurrentBonusCandiesObtained = 1;
        defaultCurrentBonusGoldObtained = 1;

        currentBonusCandiesObtained = 1;
        currentBonusGoldObtained = 1;

        currentIntervalAutoClick = 1.0f;
    }

    private void Update()
    {
        AutoClick();
    }

    public void AutoClick()
    {
        if (autoClickActive && PlayersController.Instance.canAttack)
        {
            timerAutoDamage += Time.deltaTime;

            float interval = currentIntervalAutoClick * currentBonusIntervalAutoClickPercent / 100;
            interval = currentIntervalAutoClick - interval;
            if (timerAutoDamage >= interval)
            {
                timerAutoDamage = 0.0f;

                if (this != PlayersController.Instance.currentCharacterSelected)
                {
                    Debug.Log(name + " Auto attacks !");
                    PlayersController.Instance.Hit(this.currentDamagePerClick, EntitiesManager.Instance.Enemy, this, false);
                }
            }
        }
    }

    public void InitCharacterData(CharacterData _characterData)
    {
        characterData = _characterData;

        name = characterData.characterName;

        portraitImage.sprite = characterData.portraitSprite;

        maxPowerValue = _characterData.maxPowerValue;
        powerBar.maxValue = maxPowerValue;
        UpdatePowerBar();
    }

    public IEnumerator LaunchAbility()
    {
        Enemy enemy = EntitiesManager.Instance.Enemy;
        TimerObjectDuration _rush = Instantiate(characterData.specialAbility.RushActivationPrefab,
            enemy.transform.position, Quaternion.identity);

        PlayersController.Instance.canAttack = false;

        yield return new WaitForSeconds(_rush.LifeTime);
        
        characterData.specialAbility.Attack(this);
        StartCoroutine(characterData.specialAbility.SpecialFxHitFeedback.CoroutineExecute(enemy.gameObject));
        AllosiusDev.AudioManager.Play(PlayersController.Instance.SfxHit.sound);

        characterData.specialAbility.ApplySpecialEffect(this);
        StartCoroutine(characterData.specialAbility.SpecialEffectDuration(this));

        PlayersController.Instance.canAttack = true;
    }

    public void ChangeCharacterControlled()
    {
        AllosiusDev.AudioManager.Play(sfxUseButtonPressed.sound);

        GUIManager.Instance.ChangeCharacterSelected(this);
    }

    public void SelectCharacter(bool value)
    {
        activeBorder.SetActive(value);
    }

    public void UpdatePowerBar()
    {
        powerBar.value = powerValue;

        if(powerValue >= maxPowerValue)
        {
            powerValue = maxPowerValue;
            canUsePower = true;
            buttonUseText.GetComponent<TextMeshProUGUI>().color = buttonUseTextActiveColor;
            buttonUse.interactable = true;
        }
        else
        {
            canUsePower = false;
            buttonUseText.GetComponent<TextMeshProUGUI>().color = buttonUseTextInactiveColor;
            buttonUse.interactable = false;
        }
    }

    public void ChangePowerBarValue(float _amount)
    {
        powerValue += _amount;

        UpdatePowerBar();
    }

    public void UsePower()
    {
        AllosiusDev.AudioManager.Play(sfxUseButtonPressed.sound);

        if (canUsePower && PlayersController.Instance.canAttack)
        {
            Debug.Log(gameObject.name + " Use Power");

            ChangePowerBarValue(-powerValue);

            AllosiusDev.AudioManager.Play(sfxRushActivation.sound);

            StartCoroutine(LaunchAbility());
        }
    }

    #endregion
}
