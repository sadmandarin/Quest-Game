using UnityEngine;

public abstract class QuestConditionBase
{
    protected QuestRuntime _runtime;

    public abstract void Init(QuestRuntime questRuntime, QuestConditionStep step);
}
