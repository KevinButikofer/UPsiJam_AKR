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
    private Animator animator;

    public bool isFreezed = false;

    public TextMeshProUGUI scoreText;
    
    private SpriteRenderer sr;

    private MusicController mc;

    public AudioClip ac_jump;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = weight;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        mc = GameObject.FindObjectOfType<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (gameObject.layer == LayerMask.NameToLayer("PlayersCollisions"))
                gameObject.layer = LayerMask.NameToLayer("Players");
            else
                gameObject.layer = LayerMask.NameToLayer("PlayersCollisions");
        }
        if (isFreezed)
        {
            sr.color = new Color(0.3f, 0.3f, 0.3f, 1);
            return;
        }
        else
            sr.color = Color.white;

        grounded = Mathf.Abs(rb.velocity.y) < 1e-3;

        float f = Input.GetAxis("Horizontal");
        if (Mathf.Abs(f) < 1e-3 && Mathf.Abs(rb.velocity.x) > 1e-3) rb.AddForce(new Vector2(rb.velocity.x * -200f * Time.deltaTime, 0));
       
        rb.AddForce(new Vector2(f * 1000 * Time.deltaTime, 0));
        float v = Mathf.Abs(rb.velocity.x);
        
        float sign;
        if(v < 1e-4){
            sign = 1;
        }
        else{
            sign = rb.velocity.x / v;
        }
        rb.velocity = new Vector2(Mathf.Min(v, maxSpeed) * sign, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            mc.PlaySFX(ac_jump);
            rb.AddForce(new Vector2(0, 1000));
        }

        scoreText.text = score.ToString();        

        if (Mathf.Abs(rb.velocity.x) > 1e-3 && !animator.GetBool("isMoving"))
            animator.SetBool("isMoving", true);
        else if(Mathf.Abs(rb.velocity.x) < 1e-3 && animator.GetBool("isMoving"))
            animator.SetBool("isMoving", false);

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * sign, transform.localScale.y, transform.localScale.z);
        Transform cT = transform.Find("Canvas").transform;
        cT.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * sign, cT.transform.localScale.y, cT.transform.localScale.z);
    }
}
