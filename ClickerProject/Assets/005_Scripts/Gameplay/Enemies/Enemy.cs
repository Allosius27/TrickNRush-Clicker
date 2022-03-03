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

    private int _previousLifesModifiersPercent;

    private string enemyName;
    private string enemyNickname;

    private List<string> possiblesNames = new List<string>();
    private List<string> possiblesNicknames = new List<string>();

    private EnemyVisual visual;

    private int hitIndex = 0;

    #endregion

    #region Properties

    public int Life => life;

    public int LifeMax => lifeMax;

    public Canvas LocalCanvas => localCanvas;

    public EnemyData currentEnemyData { get; protected set; }

    #endregion

    #region UnityInspector

    [SerializeField] private GameObject graphicsObject;

    [Space]

    [SerializeField] private Canvas localCanvas;

    [SerializeField] private TextMeshProUGUI textLife;
    [SerializeField] private Image fillImageLife;

    [SerializeField] private TextMeshProUGUI textName;

    #endregion

    #region Behaviour

    public void SetEnemy(EnemyData infos)
    {
        if (currentEnemyData != null)
        {
            _previousLifesModifiersPercent += currentEnemyData.healthModifierPercent;
        }

        currentEnemyData = infos;
        possiblesNames.Clear();
        possiblesNicknames.Clear();

        for (int i = 0; i < currentEnemyData.listNames.possiblesNames.Count; i++)
        {
            possiblesNames.Add(currentEnemyData.listNames.possiblesNames[i]);
        }
        for (int i = 0; i < currentEnemyData.listNicknames.possiblesNames.Count; i++)
        {
            possiblesNicknames.Add(currentEnemyData.listNicknames.possiblesNames[i]);
        }

        int _lifeModifier = currentEnemyData.startLife * _previousLifesModifiersPercent / 100;
        lifeMax = _lifeModifier + currentEnemyData.startLife;
        life = lifeMax;

        SetEnemyVisual();

        SetEnemyName();

        UpdateName();
        UpdateLife();
    }

    private void SetEnemyName()
    {
        int rndName = 0;
        while (possiblesNames[rndName] == enemyName)
        {
            //rndName = Random.Range(0, infos.listNames.possiblesNames.Count);
            rndName = IntUtil.Random(0, possiblesNames.Count);
        }
        enemyName = possiblesNames[rndName];
        possiblesNames = IntUtil.RandomizeList(possiblesNames);

        int rndNickname = 0;
        while (possiblesNicknames[rndNickname] == enemyNickname)
        {
            //rndNickname = Random.Range(0, infos.listNicknames.possiblesNames.Count);
            rndNickname = IntUtil.Random(0, possiblesNicknames.Count);
        }
        enemyNickname = possiblesNicknames[rndNickname];
        possiblesNicknames = IntUtil.RandomizeList(possiblesNicknames);
    }

    private void SetEnemyVisual()
    {
        if (visual != null)
        {
            Destroy(visual.gameObject);
        }
        visual = Instantiate(currentEnemyData.visual, graphicsObject.transform, false);
        visual.transform.localPosition = Vector3.zero;
    }

    public void LaunchHitAnimation()
    {
        visual.Animator.SetTrigger("Hurt");
        visual.Animator.SetInteger("Hit", hitIndex);

        hitIndex++;
        if (hitIndex >= currentEnemyData.hitAnimationsNumber)
        {
            hitIndex = 0;
        }
    }

    public void TakeDamage(int _amount)
    {
        

        life -= _amount;

        if(life <= 0)
        {
            life = 0;
        }

        graphicsObject.transform.DOComplete();
        graphicsObject.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);

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
