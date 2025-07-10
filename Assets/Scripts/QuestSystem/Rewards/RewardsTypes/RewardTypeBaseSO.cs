using UnityEngine;

[CreateAssetMenu(fileName = "RewardTypeBaseSO", menuName = "Scriptable Objects/RewardTypeBaseSO")]
public abstract class RewardTypeBaseSO : ScriptableObject
{
    public string RewardName;
    public string RewardID;

    public abstract void ApplyRewards();
}
