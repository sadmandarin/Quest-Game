using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSystemSO", menuName = "Scriptable Objects/QuestSystem/QuestSystemSO")]
public class QuestSystemSO : ScriptableObject
{
    public List<QuestSO> Quests;

    public QuestSO GetQuestByID(string id)
    {
        return Quests.Find(x => x.QuestID == id);
    }
}

