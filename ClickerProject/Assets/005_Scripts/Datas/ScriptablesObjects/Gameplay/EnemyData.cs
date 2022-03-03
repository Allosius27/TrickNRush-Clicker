using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Clicker/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public NamesData listNames;
    public NamesData listNicknames;

    [Space]

    public int startLife;
    //public Sprite sprite;
    public GameObject visual;

    [Space]

    [Range(0, 100)]
    public int healthModifierPercent;
}
