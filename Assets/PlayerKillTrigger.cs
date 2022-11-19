using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillTrigger : MonoBehaviour
{

    private float counter;
    private float step = 1.0f/60.0f;
    private bool animation_start;

    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("killer")) {
            animation_start = true;
            counter = 0;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
