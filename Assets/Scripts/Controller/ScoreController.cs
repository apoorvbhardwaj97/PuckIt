using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    //private function
    [SerializeField] private Transform topBar;
    [SerializeField] private Transform botBar;
    [SerializeField] private Transform bonusBar;
    [SerializeField] private UIView uIView;
    private float top;
    private float bot;
    private float bounusPos;
    private bool currentPuckViewAssigned;
    private float currentPuckPos;
    private PuckView currentPuckView;
    private int currentPuckScore = 0;
    private int totalScore = 0;

    //public Function
    public void AssignCurrentPuckView(PuckView view)
    {
        currentPuckView = view;
        top = topBar.position.y;
        bot = botBar.position.y;
        bounusPos = bonusBar.position.y;
        currentPuckPos = currentPuckView.transform.position.y;
    }

    private void Update()
    {
        if (currentPuckView != null)
        {
            if (CheckBonusZone())
            {
                currentPuckScore = 100;
                StoreCurrentPuckScore();
                uIView.UpdateScoreUI(currentPuckScore, totalScore);
            }
            else
            {
                CalculateCurrentScore();
            }
        }
    }

    public void StoreCurrentPuckScore()
    {
        totalScore += currentPuckScore;
    }

    public float CalculateCurrentScore()
    {
        currentPuckPos = currentPuckView.transform.position.y;
        currentPuckScore = (int)((currentPuckPos - bot) * 100 / (top - bot));

        uIView.UpdateScoreUI(currentPuckScore, totalScore);
        return currentPuckScore;
    }

    public bool CheckBonusZone()
    {
        if (currentPuckPos > bounusPos)
        {
            return true;
        }
        return false;
    }
}
