using UnityEngine;

public class PuzzleSolvedCondition : QuestConditionBase
{
    private string _puzzleNeedToSolveID;

    public override void Init(QuestRuntime questRuntime, QuestConditionStep step)
    {
        _runtime = questRuntime;
        _puzzleNeedToSolveID = step.ConditionID;

        EventBus.Subscribe<EnterCodeEvent>(OnEventReact);
    }

    private void OnEventReact(EnterCodeEvent evt)
    {
        if (evt.PuzzleID == _puzzleNeedToSolveID)
        {
            //обработка в runtime!!!
            
        }
        
    }

}
