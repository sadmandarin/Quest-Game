using UnityEngine;

public readonly struct DiaryPageAddedEvent
{
    public readonly DiaryPageRuntimeData runtimeData;

    public DiaryPageAddedEvent (DiaryPageRuntimeData runtimeData)
    {
        this.runtimeData = runtimeData;
    }
}
