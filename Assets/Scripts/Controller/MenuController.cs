using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private ScenesData scenesData;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private HighScoreData highScoreData;

    //private functions
    private void Start()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        highScoreText.text = (highScoreData.highScore).ToString();
    }

    //public functions
    public void LoadGameScene()
    {
        SceneManager.LoadScene(scenesData.gameScene);
    }

}
