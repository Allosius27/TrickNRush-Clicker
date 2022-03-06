using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFxInstantiate : FxInstiantiate
{
    #region Fields

    #endregion

    #region UnityInspector

    [SerializeField] private List<GameObject> listFxObjects = new List<GameObject>();

    [SerializeField] private Vector3 maxScale;

    [SerializeField] private float growScaleInterval;

    #endregion

    #region Behaviour

    public Vector3 SetFxObjectsScale(Vector3 _currentFxScale)
    {
        Vector3 currentScale = Vector3.one;

        for (int i = 0; i < listFxObjects.Count; i++)
        {
            float difference = Vector3.Distance(_currentFxScale, maxScale);
            if(difference > 0.2f)
            {
                listFxObjects[i].transform.localScale = new Vector3(_currentFxScale.x + growScaleInterval,
                    _currentFxScale.y + growScaleInterval, _currentFxScale.z + growScaleInterval);
            }
            else
            {
                listFxObjects[i].transform.localScale = _currentFxScale;
            }

            currentScale = listFxObjects[i].transform.localScale;
        }

        return currentScale;
    }

    #endregion
}
