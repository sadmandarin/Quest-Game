using UnityEngine;

public readonly struct EnterCodeEvent
{
    public readonly string PuzzleID;
    public readonly string QuestCombination;

    public EnterCodeEvent(string QuestID, string QuestCombination)
    {
        this.PuzzleID = QuestID;
        this.QuestCombination = QuestCombination;
    }
}

public readonly struct CodeResultEvent
{
    public readonly string PuzzleID;
    public readonly bool IsCorrected;

    public CodeResultEvent(string questId, bool isCorrected)
    {
        PuzzleID = questId;
        IsCorrected = isCorrected;
    }
}
