using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateScoreItem : MonoBehaviour
{

    private MusicController mc;
    public AudioClip ac_2x;
    private bool used;


    void Start()
    {
        mc = GameObject.FindObjectOfType<MusicController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!used)
        {
            if (other.CompareTag("Player"))
            {
                mc.PlaySFX(ac_2x);
                other.GetComponent<PlayerController>().score *= 2;
                Destroy(gameObject);
                used = true;
            }
        }
    }
}
