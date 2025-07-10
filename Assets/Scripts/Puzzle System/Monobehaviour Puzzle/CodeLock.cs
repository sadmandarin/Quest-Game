using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : PuzzleMonoBase
{
    [Header("Puzzle Letters")]
    [SerializeField] private List<char> _firstLetters;
    [SerializeField] private List<char> _secondLetters;
    [SerializeField] private List<char> _thirdLetters;

    [SerializeField] private TextMeshProUGUI _firstLetter;
    [SerializeField] private TextMeshProUGUI _secondLetter;
    [SerializeField] private TextMeshProUGUI _thirdLetter;

    [Header("Buttons")]
    [SerializeField] private Button _firstUpButton;
    [SerializeField] private Button _firstDownButton;
    [SerializeField] private Button _secondUpButton;
    [SerializeField] private Button _secondDownButton;
    [SerializeField] private Button _thirdUpButton;
    [SerializeField] private Button _thirdDownButton;
    [SerializeField] private Button _enterButton;

    private string _enteredCode;
    private int _firstIndex = 0;
    private int _secondIndex = 0;
    private int _thirdIndex = 0;

    private Tween _wrongCombTween;
    private Tween _rightCombTween;

    [ContextMenu("Activate")]
    public override void Activate()
    {
        PuzzleManager.Instance.ActivatePuzzle(_puzzleID);

        _enteredCode = $"{_firstLetters[_firstIndex]}{_secondLetters[_secondIndex]}{ _thirdLetters[_thirdIndex]}";

        UpdateLetters();

        _firstDownButton.onClick.AddListener(() => ChangeLetter(ref _firstIndex, -1, _firstLetter, _firstLetters));
        _firstUpButton.onClick.AddListener(() => ChangeLetter(ref _firstIndex, +1, _firstLetter, _firstLetters));

        _secondDownButton.onClick.AddListener(() => ChangeLetter(ref _secondIndex, -1, _secondLetter, _secondLetters));
        _secondUpButton.onClick.AddListener(() => ChangeLetter(ref _secondIndex, 1, _secondLetter, _secondLetters));

        _thirdDownButton.onClick.AddListener(() => ChangeLetter(ref _thirdIndex, -1, _thirdLetter, _thirdLetters));
        _thirdUpButton.onClick.AddListener(() => ChangeLetter(ref _thirdIndex, 1, _thirdLetter, _thirdLetters));

        _enterButton.onClick.AddListener(Complete);

        EventBus.Subscribe<CodeResultEvent>(OnCodeResultReaction);
    }

    protected override void Start()
    {
        base.Start();
        Activate();
    }

    private void UpdateLetters()
    {
        _firstLetter.text = _firstLetters[_firstIndex].ToString();
        _secondLetter.text = _secondLetters[_secondIndex].ToString();
        _thirdLetter.text = _thirdLetters[_thirdIndex].ToString();
    }

    private void ChangeLetter(ref int index, int delta, TextMeshProUGUI letterText, List<char> letters)
    {
        index = (index + delta + letters.Count) % letters.Count;
        letterText.text = letters[index].ToString();
    }

    public override void Deactivate()
    {
        _firstDownButton.onClick.RemoveAllListeners();
        _firstUpButton.onClick.RemoveAllListeners();

        _secondDownButton.onClick.RemoveAllListeners();
        _secondUpButton.onClick.RemoveAllListeners();

        _thirdDownButton.onClick.RemoveAllListeners();
        _thirdUpButton.onClick.RemoveAllListeners();

        _enterButton.onClick.RemoveAllListeners();

        _wrongCombTween?.Kill();
        _rightCombTween?.Kill();

        EventBus.Unsubscribe<CodeResultEvent>(OnCodeResultReaction);
    }

    public override void Complete()
    {
        _enteredCode = $"{_firstLetters[_firstIndex]}{_secondLetters[_secondIndex]}{_thirdLetters[_thirdIndex]}";

        EventBus.Publish(new EnterCodeEvent(_puzzleRuntimeData.PuzzleID, _enteredCode));
    }

    private void OnCodeResultReaction(CodeResultEvent evt)
    {
        if (evt.PuzzleID != _puzzleRuntimeData.PuzzleID) return;

        if (evt.IsCorrected)
            DoCorrectTween();
        else
            DoIncorrectTween();
    }

    private void DoCorrectTween()
    {
        //unlock tween maybe
    }

    private void DoIncorrectTween()
    {
        if (_wrongCombTween != null)
        {
            _wrongCombTween.Kill();
            _wrongCombTween = null;
        }

        _wrongCombTween = transform.DOShakePosition(0.5f, new Vector3(10, 0,0), 10, 70, false, true, ShakeRandomnessMode.Harmonic);
    }
}
