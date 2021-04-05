using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIView : MonoBehaviour
{
    //private variables
    [SerializeField] private TextMeshProUGUI pucksLeftText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI endGameHighScore;
    [SerializeField] private TextMeshProUGUI endGameNoHs;
    [SerializeField] private TextMeshProUGUI endGameYourScore;
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject noHighScorePanel;

    void Start()
    {
        UpdateScoreUI(0, 0);
    }

    //public functions
    public void UpdatePuckLeftUI(int pucksLeft)
    {
        if (pucksLeft >= 0)
        { pucksLeftText.text = pucksLeft.ToString(); }
    }

    public void UpdateScoreUI(int currentScore, int totalScore)
    {
        currentScoreText.text = currentScore.ToString();
        totalScoreText.text = totalScore.ToString();
    }

    public void UpdateHighScore(int highScore, int youScore)
    {
        endGameHighScore.text = highScore.ToString();
        endGameNoHs.text = highScore.ToString();
        endGameYourScore.text = youScore.ToString();
    }

    public void OpenEndGamePanel(bool highScore)
    {
        if (highScore)
        {
            highScorePanel.SetActive(true);
            noHighScorePanel.SetActive(false);
        }
        else
        {
            highScorePanel.SetActive(false);
            noHighScorePanel.SetActive(true);
        }
    }
}
