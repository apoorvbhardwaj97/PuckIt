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
}
