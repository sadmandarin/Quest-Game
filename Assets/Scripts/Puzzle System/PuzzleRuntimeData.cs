using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PuzzleRuntimeData
{
    public string PuzzleID;
    public int CurrentProgress;
    [SerializeReference]
    public PuzzleConditionBase Condition;
    private PuzzleSOBase _puzzleSOBase;

    public PuzzleSOBase PuzzleSOBase => _puzzleSOBase;

    public bool IsCompleted;

    public PuzzleRuntimeData() { }

    public PuzzleRuntimeData(string puzzleID)
    {
        PuzzleID = puzzleID;
    }

    public void InjectSO(PuzzleSOBase puzzleSO)
    {
        _puzzleSOBase = puzzleSO;
    } 
    public void InjectCondition()
    {
        if (_puzzleSOBase?.Condition == null)
            return;

        if (Condition == null)
        {
            Condition = _puzzleSOBase.Condition.Clone() as PuzzleConditionBase;
        }
            
        Condition.InjectRuntime(this);
    }


    public void CompletePuzzle()
    {
        if (IsCompleted) return;

        IsCompleted = true;
        Condition.DisposeCondition();
    }
}
