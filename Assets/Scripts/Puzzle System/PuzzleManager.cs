using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public List<PuzzleRuntimeData> PuzzlesRuntimeData = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (var puzzle in PuzzleDatabase.Instance.puzzles)
        {
            GenerateRuntimePuzzleData(puzzle);
        }
    }

    public void GenerateRuntimePuzzleData(PuzzleSOBase puzzle)
    {
        var runtimePuzzle = GetPuzzleByID(puzzle.PuzzleID);

        if (runtimePuzzle == null)
        {
            if (puzzle != null)
            {
                runtimePuzzle = new(puzzle.PuzzleID);
                PuzzlesRuntimeData.Add(runtimePuzzle);
            }
        }

        runtimePuzzle.InjectSO(puzzle);
    }

    public PuzzleRuntimeData GetPuzzleByID(string id)
    {
        return PuzzlesRuntimeData.Find(x => x.PuzzleID == id);
    }

    public void ActivatePuzzle(string puzzleID)
    {
        var puzzleRuntime = GetPuzzleByID(puzzleID);

        puzzleRuntime?.InjectCondition();
    }
}
