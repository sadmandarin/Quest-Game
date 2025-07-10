using UnityEngine;

public class TestPuzzleMonobehaviour : MonoBehaviour
{
    //Тестовый метод!!!
    public void CompletePuzzle(string questID, string comb) => EventBus.Publish(new EnterCodeEvent(questID, comb));
}
