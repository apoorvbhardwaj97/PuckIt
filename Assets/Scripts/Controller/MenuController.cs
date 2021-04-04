using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private ScenesData scenesData;
    //public functions
    public void LoadGameScene()
    {
        SceneManager.LoadScene(scenesData.gameScene);
    }
}
