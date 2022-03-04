using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxInstiantiate : MonoBehaviour
{
    #region Properties

    public ParticleSystem FxParticleSystem => fxParticleSystem;

    #endregion

    #region UnityInspector

    [SerializeField] private ParticleSystem fxParticleSystem;

    #endregion

    #region Behaviour

    private void Start()
    {
        if(fxParticleSystem != null)
        {
            Destroy(gameObject, fxParticleSystem.main.startLifetime.constantMax);
        }
    }

    #endregion
}
