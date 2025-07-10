using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleDatabase", menuName = "Scriptable Objects/PuzzleDatabase")]
public class PuzzleDatabase : ScriptableSingleton<PuzzleDatabase>
{
    public List<PuzzleSOBase> puzzles;

    public PuzzleSOBase GetPuzzleByID(string id)
    {
        return puzzles.Find(x => x.PuzzleID == id);
    }
}
