using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneMenuManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshTime;
    public TextMeshProUGUI textMeshScore;
    // Start is called before the first frame update
    void Start()
    {
        textMeshScore.text = "Total score: " + GameManager.collected.ToString();
        float time = GameManager.totalTime;
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        textMeshTime.text = "Total time: " + string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
