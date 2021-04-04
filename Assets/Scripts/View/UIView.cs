using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIView : MonoBehaviour
{
    //private variables
    [SerializeField] private TextMeshProUGUI pucksLeftText;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {

    }

    void Update()
    {

    }

    //public functions
    public void UpdatePuckLeftUI(int pucksLeft)
    {
        if (pucksLeft >= 0)
        { pucksLeftText.text = pucksLeft.ToString(); }
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
