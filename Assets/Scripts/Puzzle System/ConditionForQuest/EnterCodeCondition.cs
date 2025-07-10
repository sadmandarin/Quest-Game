using System;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class EnterCodeCondition : PuzzleConditionBase<EnterCodeEvent>
{
    public string Combination;
    
    public override object Clone()
    {
        return new EnterCodeCondition
        {
            Combination = Combination
        };
    }

    protected override void HandleEvent(EnterCodeEvent evt)
    {
        if (evt.PuzzleID != _runtime.PuzzleID) return;

        bool isCorrected = evt.QuestCombination == Combination;

        if (isCorrected)
        {
            Debug.Log("Idex is Correct");
            _runtime.CompletePuzzle();
        }
        EventBus.Publish(new CodeResultEvent(_runtime.PuzzleID, isCorrected));
    }
}
