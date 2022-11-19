using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    private AudioSource as_music;
    private AudioSource as_sfx;

    // Start is called before the first frame update
    void Start()
    {
        as_music = GetComponents<AudioSource>()[0];
        as_music.loop = true;
        as_sfx = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(AudioClip ac)
    {
        Play(as_music, ac, false);
    }

    public void PlaySFX(AudioClip ac)
    {
        Play(as_sfx, ac, true);
    }

    private void Play(AudioSource as_, AudioClip ac, bool bypass)
    {
        if(bypass || as_.clip == null || as_.clip != null && as_.clip.name != ac.name){
            as_.clip = ac;
            as_.Play();
        }
    }
}
