using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private ScenesData scenesData;
    [SerializeField] private TextMeshProUGUI highScoreText;

    //private functions
    private void Start()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        highScoreText.text = Getint("HighScore").ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    //public functions
    public void LoadGameScene()
    {
        SceneManager.LoadScene(scenesData.gameScene);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

}
