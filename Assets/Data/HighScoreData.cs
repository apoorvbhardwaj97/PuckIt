using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/HighScoreData")]
public class HighScoreData : ScriptableObject
{
    public int highScore;

    public void SetHighScore(int score)
    {
        highScore = score;

    }

}
