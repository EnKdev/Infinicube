using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class SceneChangerScript : MonoBehaviour
{
    public Button Button;
    public string Scene;

    private void Start()
    {
        Button.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        RandomFactScript.randFactTimer.Enabled = false;
        SceneManager.LoadSceneAsync(Scene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitGame();
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
