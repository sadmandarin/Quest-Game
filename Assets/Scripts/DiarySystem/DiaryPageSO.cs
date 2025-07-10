using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiaryPageSO", menuName = "Scriptable Objects/DiaryPageSO")]
public class DiaryPageSO : ScriptableObject
{
    public string ID;
    public string PageName;
    public int PageIndex;
    public List<PagePiece> PagePieces;
}

[Serializable]
public class PagePiece
{
    public string ID;
    public List<string> PagePieceText;
    public List<Sprite> PagePieceIcons;
}
