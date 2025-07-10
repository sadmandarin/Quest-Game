using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    public static DiaryManager Instance;

    private List<DiaryPageRuntimeData> diaryData = new();

    public IReadOnlyList<DiaryPageRuntimeData> DyaryData => diaryData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InitFromSaveFile(List<string> savedPages)
    {
        foreach (var pageID in savedPages)
            OpenDiaryPage(pageID);
    }

    public void AddDiaryPage(DiaryPageRuntimeData diaryRuntimeData)
    {
        if (diaryRuntimeData != null && !diaryData.Any(p => p.ID == diaryRuntimeData.ID))
        {
            diaryData.Add(diaryRuntimeData);
            EventBus.Publish(new DiaryPageAddedEvent(diaryRuntimeData));
            diaryData.Sort((a, b) => a.PageIndex.CompareTo(b.PageIndex));
            GlobalGameManager.Instance.PlayerData.AddDiaryPage(diaryRuntimeData.ID);
        }
    }


    public void OpenDiaryPage(string ID)
    {
        var page = DiarySO.Instance.GetPageSoByID(ID);
        if (page != null)
        {
            var diaryPageRuntime = new DiaryPageRuntimeData(page);

            AddDiaryPage(diaryPageRuntime);
        }
        else
            Debug.LogError("There is no page with that ID. Please check this page in DiarySO");
    }
}

[Serializable]
public class DiaryPageRuntimeData
{
    public string ID;
    public string PageName;
    public int PageIndex;
    public List<PagePiece> PagePieces;

    public DiaryPageRuntimeData(DiaryPageSO diaryPage)
    {
        ID = diaryPage.ID;
        PageName = diaryPage.PageName;
        PageIndex = diaryPage.PageIndex;
        PagePieces = diaryPage.PagePieces;
    } 
}

