using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerScript : MonoBehaviour
{
    private GameObject playerContainer;

    public GameObject playerFactory;

    private MusicController mc;

    public AudioClip ac_addplayer;

    private bool used = false;

    // Start is called before the first frame update
    void Start()
    {
        playerContainer = GameObject.Find("Players");
        mc = GameObject.FindObjectOfType<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!used)
        {
            if (collider.tag == "Player")
            {
                mc.PlaySFX(ac_addplayer);
                Instantiate(playerFactory, transform.position, Quaternion.identity, playerContainer.transform);
                Destroy(gameObject);
                used = true;
            }
        }
    }
}
