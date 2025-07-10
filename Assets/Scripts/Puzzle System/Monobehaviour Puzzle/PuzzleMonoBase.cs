using UnityEngine;

public abstract class PuzzleMonoBase : MonoBehaviour
{
    [SerializeField] protected string _puzzleID;

    protected PuzzleRuntimeData _puzzleRuntimeData;

    protected virtual void Start()
    {
        _puzzleRuntimeData = PuzzleManager.Instance.GetPuzzleByID(_puzzleID);
    }

    public abstract void Activate();
    public abstract void Deactivate();
    public abstract void Complete();
}
