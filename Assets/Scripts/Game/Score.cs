using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int MyScore { get; private set; }
    private TextMeshProUGUI tmpScore;
    void Awake()
    {
        tmpScore = gameObject.GetComponent<TextMeshProUGUI>();
        MyScore = 0;
        tmpScore.SetText("Score: " + MyScore);
    }
    public void SetScore(int value)
    {
        MyScore += value;
        tmpScore.SetText($"Score {MyScore}");
    }
}
