using UnityEngine;

public class TestPuzzleMonobehaviour : MonoBehaviour
{
    //�������� �����!!!
    public void CompletePuzzle(string questID, string comb) => EventBus.Publish(new EnterCodeEvent(questID, comb));
}
