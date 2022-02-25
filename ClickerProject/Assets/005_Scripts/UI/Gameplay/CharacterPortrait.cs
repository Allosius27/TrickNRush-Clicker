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

    #endregion

    #region Properties

    public CharacterData characterData { get; protected set; }

    #endregion

    #region UnityInspector

    [SerializeField] private Image portraitImage;

    [Space]

    [SerializeField] private GameObject activeBorder;

    [Space]

    [SerializeField] private Button buttonUse;
    [SerializeField] private GameObject buttonUseText;
    [SerializeField] private Color buttonUseTextActiveColor;
    [SerializeField] private Color buttonUseTextInactiveColor;

    [Space]

    [SerializeField] private Slider powerBar;

    #endregion

    #region Behaviour

    public void InitCharacterData(CharacterData _characterData)
    {
        characterData = _characterData;

        name = characterData.characterName;

        portraitImage.sprite = characterData.portraitSprite;

        maxPowerValue = _characterData.maxPowerValue;
        powerBar.maxValue = maxPowerValue;
        UpdatePowerBar();
    }

    public void ChangeCharacterControlled()
    {
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
        if (canUsePower)
        {
            ChangePowerBarValue(-powerValue);

            Debug.Log(gameObject.name + " Use Power");
        }
    }

    #endregion
}
