using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndSceneMenuManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshTime;
    public TextMeshProUGUI textMeshScore;
    // Start is called before the first frame update
    void Start()
    {   
        DateTime endTime = DateTime.Now;
    
        int collected = GameManager.collectedLevel1+GameManager.collectedLevel2+GameManager.collectedLevel3+GameManager.collectedLevel4;
        textMeshScore.text = "Total score: " + collected.ToString();
        TimeSpan time = endTime-GameManager.startTime;
        textMeshTime.text = "Total time: " + time.ToString("h'h 'm'm 's's'");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
