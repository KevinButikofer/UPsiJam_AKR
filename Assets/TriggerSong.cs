using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSong : MonoBehaviour
{
    private MusicController mc;

    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.FindObjectOfType<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player")) {
            mc.Play(audioClip);
        }
    }
}
