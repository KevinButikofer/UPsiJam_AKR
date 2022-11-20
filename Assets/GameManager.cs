using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.SceneManagement;

public class GameManager
{

    public static int collected = 0;
    public static float totalTime = 0f;

    private static string[] scenes = {"Niveau 1", "Niveau 2", "Niveau 3", "Niveau 3", "End Scene" };

    private static int currentScene = 0;

    public static void NextScene()
    {
        currentScene++;
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
