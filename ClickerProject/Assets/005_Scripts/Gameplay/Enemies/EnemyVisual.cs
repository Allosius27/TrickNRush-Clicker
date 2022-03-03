using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    #region Properties

    public Animator Animator => animator;

    #endregion

    #region UnityInspector

    [SerializeField] private Animator animator;

    #endregion
}
