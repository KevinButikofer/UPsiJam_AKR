using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private float weight = 1;

    [SerializeField]
    public int score;

    private Rigidbody2D rb;
    private bool grounded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = weight;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = rb.velocity.y == 0;

        float f = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(f * 500 * Time.deltaTime, 0));
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, 400));
        }
    }
}
