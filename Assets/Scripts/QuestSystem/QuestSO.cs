using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Scriptable Objects/QuestSystem/QuestSO")]
public class QuestSO : ScriptableObject
{
    public string QuestID;
    public string Name;
    public string Title;
    public string Description;
    public List<QuestStepSO> QuestSteps;
    public List<RewardSO> Rewards;
    public List<QuestSO> RequiredQuests;
}



