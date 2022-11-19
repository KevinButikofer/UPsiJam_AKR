using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillTrigger : MonoBehaviour
{

    private float counter;
    private float step = 1.0f/(3*60.0f);
    private bool animation_start;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private MusicController mc;

    public AudioClip ac_death;
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        mc = GameObject.FindObjectOfType<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animation_start) {
            counter += step;
            counter = Mathf.Min(1, counter);
            sr.color = new Color(1, 1 - counter, 1 - counter);
        }

        if(counter >= 1 || transform.position.y < -5) {
            Destroy(this.gameObject);
            if(GameObject.FindGameObjectsWithTag("Player").Length <= 1)
            {
                GameManager.collected = 0;
                GameManager.RestartScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("killer")) {
            Kill();
        }
    }

    public void Kill()
    {
        mc.PlaySFX(ac_death);
        animation_start = true;
        counter = 0;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
