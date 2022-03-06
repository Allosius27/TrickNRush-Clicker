using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    #region Properties

    public Animator Animator => animator;

    public Enemy enemy { get; protected set; }

    #endregion

    #region UnityInspector

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject hurtExpressionObject;
    [SerializeField] private GameObject neutralExpressionObject;

    #endregion

    #region Behaviour

    public void Initialize(Enemy _enemy)
    {
        enemy = _enemy;
    }

    public void EndDeathAnimation()
    {
        enemy.InstantiateDeathFx(this.gameObject);

        Destroy(gameObject, 0.25f);
    }

    public void ActiveHurtExpression()
    {
        hurtExpressionObject.SetActive(true);
        neutralExpressionObject.SetActive(false);
    }

    public void ActiveNeutralExpression()
    {
        hurtExpressionObject.SetActive(false);
        neutralExpressionObject.SetActive(true);
    }

    #endregion
}
