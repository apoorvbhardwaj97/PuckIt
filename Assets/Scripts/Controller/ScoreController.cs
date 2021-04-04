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
    private PuckView currentPuckView;
    private int currentPuckScore;
    private int totalScore;

    //public Function
    public void AssignCurrentPuckView(PuckView view)
    {
        currentPuckView = view;
    }

    private void Update()
    {
        CalculateCurrentScore();
    }

    public float CalculateCurrentScore()
    {
        var top = topBar.position.y;
        var bot = botBar.position.y;
        float puck;
        if (currentPuckView != null)
        {
            puck = currentPuckView.transform.position.y;
            currentPuckScore = (int)((puck) / (top - bot));
        }
        Debug.Log(currentPuckScore);
        uIView.UpdateScoreUI(currentPuckScore);
        return currentPuckScore;
    }

    private bool CheckBonusZone()
    {
        return false;
    }
}
