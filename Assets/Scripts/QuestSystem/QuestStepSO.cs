using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestStepSO", menuName = "Scriptable Objects/QuestSystem/QuestStepSO")]
public class QuestStepSO : ScriptableObject
{
    public string StepID;
    public string StepDescription;
    public List<QuestConditionStep> ConditionSteps;
}

[Serializable]
public class QuestConditionStep
{
    public string ConditionID;
    public ConditionType Parameter;
    public enum ConditionType
    {
        PuzzleSolved,
        ItemCollected,
        LocationVisited,
        NoteViewed,
        Custom
    }

}