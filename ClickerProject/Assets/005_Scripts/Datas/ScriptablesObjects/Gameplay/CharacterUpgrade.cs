using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterUpgrade", menuName = "Clicker/Character Upgrade")]
public class CharacterUpgrade : ScriptableObject
{
    #region Properties

    public Sprite Sprite => sprite;
    public int Cost => cost;

    #endregion

    #region UnityInspector

    [SerializeField] private Sprite sprite;
    [SerializeField] private int cost;

    #endregion
}
