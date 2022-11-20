using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    private AudioSource as_music;
    private List<AudioSource> as_sfx;

    // Start is called before the first frame update
    void Start()
    {
        as_sfx = new List<AudioSource>();
        AudioSource[] ass = GetComponents<AudioSource>();
        as_music = ass[0];
        as_music.loop = true;
        for(int i = 1; i < ass.Length; i++)
        {
            ass[i].volume = 0.5f;
            as_sfx.Add(ass[i]);
        }
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
        foreach(AudioSource as_ in as_sfx)
        {
            if(as_.isPlaying)
                continue;
            Play(as_, ac, true);
            break;
        }
    }

    private void Play(AudioSource as_, AudioClip ac, bool bypass)
    {
        if(bypass || as_.clip == null || as_.clip != null && as_.clip.name != ac.name){
            as_.clip = ac;
            as_.Play();
        }
    }
}
