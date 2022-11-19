using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float weight = 1;

    [SerializeField]
    public int score;

    private Rigidbody2D rb;
    private bool grounded = false;

    public TextMeshProUGUI scoreText;

    private float randomModifier;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = weight;
        // randomModifier = Random.Range(1f, 1.5f);
        randomModifier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Mathf.Abs(rb.velocity.y) < 1e-3;

        float f = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(f * 1000 * Time.deltaTime * randomModifier, 0));
        float v = Mathf.Abs(rb.velocity.x);
        
        float sign;
        if(v < 1e-4){
            sign = 1;
        }
        else{
            sign = rb.velocity.x / v;
        }

        rb.velocity = new Vector2(Mathf.Min(v, maxSpeed) * sign, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, 1000));
        }

        scoreText.text = score.ToString();
    }
}
