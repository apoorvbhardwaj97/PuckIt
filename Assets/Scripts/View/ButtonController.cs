using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public ScenesData scenes;
    public void RestartGame()
    {
        SceneManager.LoadScene(scenes.gameScene);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene(scenes.MenuScene);
    }

}
