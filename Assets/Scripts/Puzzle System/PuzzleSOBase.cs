using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleSOBase", menuName = "Scriptable Objects/Puzzles/PuzzleSOBase")]
public abstract class PuzzleSOBase : ScriptableObject
{
    public string PuzzleID;
    public string PuzzleName;
    public string Description;
    [SerializeReference]
    public PuzzleConditionBase Condition;
    

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(PuzzleID))
            PuzzleID = Guid.NewGuid().ToString();
    }
}

