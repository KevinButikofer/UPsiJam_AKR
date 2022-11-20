using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public AudioClip ac_collect;
    private MusicController mc;
    private bool used = false;

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
        if (!used)
        {
            if (collision.tag == "Player")
            {
                mc.PlaySFX(ac_collect);
                GameManager.collected += 1;
                Destroy(gameObject);
                used = true;
            }
        }
    }
}