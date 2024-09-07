using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 4f;
    public float jumpingPower = 4f;


    public float radius = 0.2f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheck2;

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
    public static int timer2 = 0;
    public static GameObject pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = this.gameObject;
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
        if (timer2 != 0)
        {
            timer2--;
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


        if ((Input.GetKey(KeyCode.UpArrow)) && IsGrounded())
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
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundlayer);
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheck2.position, Vector2.down, 0.1f, groundlayer);
        UnityEngine.Debug.DrawRay(groundCheck.position, Vector2.down * hit.distance, Color.red);

        if (hit.collider != null || hit2.collider != null)
        {
            return true;
        }
        return false;
    }
    private IEnumerator jumpReset()
    {
        yield return new WaitForSeconds(3);
        jumpingPower = jumpingPower / 1.75f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jumpboostorb"))
        {
            Destroy(collision.gameObject);
            powerupjump.a = true;
            jumpingPower = jumpingPower * 1.75f;
            StartCoroutine(jumpReset());
        }
        if (collision.gameObject.CompareTag("freemoveorb"))
        {
            Destroy(collision.gameObject);
            orbspawner.a = true;
            timer2 = 0;
        }
    }
}
