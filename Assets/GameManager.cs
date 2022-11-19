using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.SceneManagement;

public class GameManager
{

    public static int collected = 0;

    private static string[] scenes = {"RaphaelScene", "MainScene"};

    private static int currentScene = 0;

    public static void NextScene()
    {
        currentScene++;
        try
        {
            SceneManager.LoadScene(scenes[currentScene]);
        }
        catch
        {
            Application.Quit();
        }
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
