using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    private AudioSource as_;

    // Start is called before the first frame update
    void Start()
    {
        as_ = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip ac)
    {
        if(as_.clip == null || as_.clip != null && as_.clip.name != ac.name){
            as_.clip = ac;
            as_.Play();
        }
    }
}
