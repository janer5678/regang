using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 3f;
    public float jumpingPower = 4f;


    public float radius = 0.2f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D boxCollider2;
    public static bool crouchNow = false;
    public static bool notcrouchNow = false;
    private bool a =false;
    private bool b =false;
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = true;

    public static bool staticGunFliped;
    public static int timer1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void FlipSprite()
    {
        // Flip the sprite horizontally
        isFlipped = !isFlipped;
        staticGunFliped = true;
        spriteRenderer.flipX = isFlipped;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 != 0)
        {
            timer1--;
        }
        horizontal = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }

        if (horizontal > 0 && isFlipped)
        {
            FlipSprite();
        }
        else if (horizontal < 0 && !isFlipped)
        {
            FlipSprite();
        }
        

        animator.SetFloat("speed", Mathf.Abs(horizontal));
       
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);


        if ((Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            animator.SetBool("jumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }



        if (Input.GetKey(KeyCode.DownArrow) && IsGrounded())
        {

            animator.SetBool("crouch", true);
            speed = 1;
            boxCollider.enabled = false;
            if (a == true)
            {
                crouchNow = true;
                a = false;
            }
            b = true;


        }
        else
        {
            animator.SetBool("crouch", false);
            speed = 3;

            boxCollider.enabled = true;
            if (b == true)
            {
                notcrouchNow = true;
                b = false;
            }
            a= true;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetBool("jumping", false);
            
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, radius, groundlayer);
    }
}
