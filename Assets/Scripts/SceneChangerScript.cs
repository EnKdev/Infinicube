using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangerScript : MonoBehaviour
{
    public Button Button;
    public Button Exit;
    public string Scene;

    private void Start()
    {
        Button.onClick.AddListener(ChangeScene);
        Exit.onClick.AddListener(ExitGame);
    }

    void ChangeScene()
    {
        SceneManager.LoadSceneAsync(Scene);
    }
    
    void ExitGame()
    {
        Application.Quit();
    }
}
