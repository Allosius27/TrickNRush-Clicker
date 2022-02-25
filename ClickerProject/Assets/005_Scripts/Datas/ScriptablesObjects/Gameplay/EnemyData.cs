using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public NamesData listNames;
    public NamesData listNicknames;

    public int startLife;
    public Sprite sprite;
}
