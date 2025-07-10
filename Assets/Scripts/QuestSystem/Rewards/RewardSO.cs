using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu(fileName = "RewardSO", menuName = "Scriptable Objects/RewardSO")]
public class RewardSO : ScriptableObject
{
    public List<RewardTypeBaseSO> Rewards;
}
