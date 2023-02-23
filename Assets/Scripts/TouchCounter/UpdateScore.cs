using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public string nameOfObject;
    [SerializeField] private BallTouchHandler ballTouchHandler;
    private TextMeshProUGUI _textCounter;

    private void Start()
    {
        _textCounter = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ballTouchHandler.onBallTouch += UpdateScoreText;
    }

    private void OnDisable()
    {
        ballTouchHandler.onBallTouch -= UpdateScoreText;
    }

    private void UpdateScoreText(int count)
    {
        _textCounter.SetText(nameOfObject +": " + count);
    }
}
