using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    #region Fields

    private int life;
    private int lifeMax;

    private string enemyName;
    private string enemyNickname;

    #endregion

    #region Properties

    public Canvas LocalCanvas => localCanvas;

    #endregion

    #region UnityInspector

    [SerializeField] private GameObject visual;

    [Space]

    [SerializeField] private Canvas localCanvas;

    [SerializeField] private TextMeshProUGUI textLife;
    [SerializeField] private Image fillImageLife;

    [SerializeField] private TextMeshProUGUI textName;

    #endregion

    #region Behaviour

    private void Start()
    {
        UpdateName();
        UpdateLife();
    }

    public void SetMonster(EnemyData infos)
    {
        lifeMax = infos.startLife;
        life = lifeMax;

        visual.GetComponent<SpriteRenderer>().sprite = infos.sprite;

        int rndName = Random.Range(0, infos.listNames.possiblesNames.Count);
        enemyName = infos.listNames.possiblesNames[rndName];

        int rndNickname = Random.Range(0, infos.listNicknames.possiblesNames.Count);
        enemyNickname = infos.listNicknames.possiblesNames[rndNickname];
    }

    public void TakeDamage(int _amount)
    {
        life -= _amount;

        visual.transform.DOComplete();
        visual.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);

        UpdateLife();
    }

    public bool IsAlive()
    {
        return life > 0;
    }

    private void UpdateLife()
    {
        textLife.text = $"{life}/{lifeMax}";

        float percent = (float)life / (float)lifeMax;
        fillImageLife.fillAmount = percent;
    }

    private void UpdateName()
    {
        textName.text = $"{enemyName} {enemyNickname}";
    }

    #endregion
}
