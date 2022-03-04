using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerObjectDuration : MonoBehaviour
{
    #region Properties

    public float LifeTime => lifeTime;

    #endregion

    #region UnityInspector

    [SerializeField] private float lifeTime;

    #endregion

    #region Behaviour

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    #endregion
}
