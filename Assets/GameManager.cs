using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  
using UnityEngine.SceneManagement;

public class GameManager
{

    public static int collected = 0;
    public static int collectedLevel1 = 0;
    public static int collectedLevel2 = 0;
    public static int collectedLevel3 = 0;
    public static int collectedLevel4 = 0;

    public static float totalTime = 0f;
    public static float timeLevel1 = 0f;
    public static float timeLevel2 = 0f;
    public static float timeLevel3 = 0f;
    public static float timeLevel4 = 0f;


    public static DateTime startTime = DateTime.Now;

    private static string[] scenes = {"Niveau 1", "Niveau 2", "Niveau 3", "Niveau 3", "End Scene" };

    private static int currentScene = 0;

    public static void NextScene()
    {
        if(currentScene == 0){
            collectedLevel1 = collected;
            collected = 0;
        }else if(currentScene == 1){
            collectedLevel2 = collected;
            timeLevel2 = 
            collected = 0;
        }else if(currentScene == 2){
            collectedLevel3 = collected;
            collected = 0;
        }else if(currentScene == 3){
            collectedLevel4 = collected;
            collected = 0;
        }
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
