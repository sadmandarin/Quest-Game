using UnityEngine;

public class DiaryUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.Subscribe<DiaryPageAddedEvent>(OnPageAdded);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DiaryPageAddedEvent>(OnPageAdded);
    }

    private void OnPageAdded(DiaryPageAddedEvent evt)
    {

    }
}
