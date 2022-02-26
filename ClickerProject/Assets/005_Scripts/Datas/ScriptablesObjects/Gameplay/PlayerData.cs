using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Clicker/Player Data")]
public class PlayerData : ScriptableObject
{
    public int baseDamagePerClick;

    public int basePowerObtainedPerClick;

    public int baseGoldObtainedPerClick;
    public int baseCandiesObtainedPerClick;
}
