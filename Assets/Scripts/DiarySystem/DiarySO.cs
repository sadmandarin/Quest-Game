using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

[CreateAssetMenu(fileName = "DiarySO", menuName = "Scriptable Objects/Diary System/DiarySO")]
public class DiarySO : ScriptableSingleton<DiarySO>
{
    public List<DiaryPageSO> _pages;
    
    public DiaryPageSO GetPageSoByID(string id)
    {
        var page = _pages.Find(x => x.ID == id);

        return page != null ? page : null;
    }
}
