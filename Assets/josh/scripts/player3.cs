using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 2f;
    public float jumpingPower = 4f;

    public float radius = 0.2f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheck2;
    [SerializeField] private Transform groundCheck3;

    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D boxCollider2;
    public static bool crouchNow = false;
    public static bool notcrouchNow = false;
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = true;

    public static bool staticGunFliped;
    public static int timer1 = 0;
    public static int timer2 = 0;
    public static int shield = 1;
    public static int shieldmax = 1;
    public static bool invincible = false;
    public GameObject object1;
    public static GameObject pl3;

    // Start is called before the first frame update
    void Start()
    {
        pl3 = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2.enabled = false;

    }
    void FlipSprite()
    {
        // Flip the sprite horizontally
        isFlipped = !isFlipped;
        staticGunFliped = true;
        spriteRenderer.flipX = isFlipped;
    }
    private IEnumerator ability1()
    {
        animator.SetBool("side", true);
        Vector3 originalPosition = groundCheck.position;
        groundCheck.position = new Vector3(originalPosition.x - 0.2f, originalPosition.y + 0.2f, originalPosition.z);
        Vector3 originalPosition2 = groundCheck2.position;
        groundCheck2.position = new Vector3(originalPosition2.x + 0.2f, originalPosition2.y + 0.2f, originalPosition2.z);
        speed = speed * 3.5f;
        boxCollider2.enabled = true;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(6f);
        animator.SetBool("side", false);
        speed = speed / 3.5f;
        boxCollider2.enabled = false;
        boxCollider.enabled = true;
        originalPosition = groundCheck.position;
        originalPosition2 = groundCheck2.position;
        groundCheck.position = new Vector3(originalPosition.x + 0.2f, originalPosition.y - 0.2f, originalPosition.z);
        groundCheck2.position = new Vector3(originalPosition2.x - 0.2f, originalPosition2.y - 0.2f, originalPosition2.z);
    }
    private IEnumerator ability2()
    {
        shieldmax++;
        shield++;
        invincible = true;
        int i = 2;
        i = i + shieldmax;
        yield return new WaitForSeconds(i);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 != 0)
        {
            timer1 = timer1 - 1;
        }
        if (timer2 != 0)
        {
            timer2 = timer2 - 1;
        }
        if (Input.GetKey(KeyCode.M) && timer1 == 0)
        {
            timer1 = 4000;
            StartCoroutine(ability1());
        }
        if (Input.GetKey(KeyCode.K) && timer2 == 0)
        {
            timer2 = 4000;
            StartCoroutine(ability2());

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
        

       
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
        

        if ((Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("wall") && !collision.gameObject.CompareTag("ground"))
        {
            Destroy(collision.gameObject);
            shieldmax++;
            shield = shieldmax;
        }
    }



    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundlayer);
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheck2.position, Vector2.down, 0.1f, groundlayer);
        RaycastHit2D hit3 = Physics2D.Raycast(groundCheck3.position, Vector2.down, 0.1f, groundlayer);
        UnityEngine.Debug.DrawRay(groundCheck.position, Vector2.down * hit.distance, Color.red);
        if (hit3.collider!=null)
        {
            return true;
        }
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
        if (collision.gameObject.CompareTag("orb2"))
        {
            Destroy(collision.gameObject);
            orbspawner.a = true;
            timer2 = 0;
            timer1 = 0;
        }
    }
}
