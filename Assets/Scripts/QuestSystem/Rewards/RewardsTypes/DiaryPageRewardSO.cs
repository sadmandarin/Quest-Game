using UnityEngine;

[CreateAssetMenu(fileName = "DiaryPageRewardSO", menuName = "Scriptable Objects/DiaryPageRewardSO")]
public class DiaryPageRewardSO : RewardTypeBaseSO
{
    public override void ApplyRewards()
    {
        if (string.IsNullOrEmpty(RewardID))
        {
            Debug.LogWarning("ID is empty. Fill ID");
            return;
        }
        DiaryManager.Instance.OpenDiaryPage(RewardID);
    }
}
