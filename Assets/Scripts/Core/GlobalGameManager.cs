using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager Instance;
    public PlayerData PlayerData { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (PlayerData == null)
        {
            PlayerData = new PlayerData();
        }
    }
}

[Serializable]
public class PlayerData
{
    public string PlayerName;
    public List<string> OpenedDiaryPage = new();

    public void AddDiaryPage(string pageID)
    {
        OpenedDiaryPage.Add(pageID);
    }
}
