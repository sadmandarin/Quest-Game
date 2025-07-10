using System;
using UnityEngine;

[Serializable]
public abstract class PuzzleConditionBase
{
    protected PuzzleRuntimeData _runtime;

    public virtual void InjectRuntime(PuzzleRuntimeData puzzle)
    {
        _runtime = puzzle;
    }

    public virtual void DisposeCondition() { }

    public abstract object Clone();
}

public abstract class PuzzleConditionBase<TEvent> : PuzzleConditionBase
{
    public override void InjectRuntime(PuzzleRuntimeData puzzle)
    {
        _runtime = puzzle;
        EventBus.Subscribe<TEvent>(OnEvent);
    }

    public override void DisposeCondition()
    {
        EventBus.Unsubscribe<TEvent>(OnEvent);
    }

    private void OnEvent(TEvent evt)
    {
        HandleEvent(evt);
    }

    protected abstract void HandleEvent(TEvent evt);
}
