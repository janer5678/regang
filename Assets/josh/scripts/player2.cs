using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 4f;
    public float jumpingPower = 4f;
    public static bool kill = false;
    private float jumping = 0f;
    private float jumping2 = 0f;
    private float ability = 0f;
    public static bool bigboomerang = false;


    public float radius = 0.2f;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheck2;
    [SerializeField] private Transform ceilingCheck;

    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D boxCollider2;
    public static bool crouchNow2 = false;
    public static bool notcrouchNow2 = false;
    private bool a = false;
    private bool b = false;
    private SpriteRenderer spriteRenderer;
    private bool isFlipped2 = true;
    private bool reverseControls = false;
    private bool reverseControls2 = false;

    public static bool staticGunFliped2;
    private const int abilityCount = 7;
    public static bool bulletDirection = false;
    private bool gravityReversed = false;
    private Color originalColor;
    public static bool blue = false;
    public static float timer1 = 0;
    public static float timer2 = 0;
    public static bool blocking2 = false;
    public GameObject object1;
    private float speed2 = 4f;
    public static GameObject pl2;

    float move;
    float attack2;
    float down;
    float up;
    public static bool invincible = false;

    public static float attack1;
    Josh2Controls controls;

    void Awake()
    {
        controls = new Josh2Controls();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;

        controls.Josh2.Down.performed += ctx => down = ctx.ReadValue<float>();
        controls.Josh2.Down.canceled += ctx => down = 0f;
        
        
        controls.Josh2.Up.performed += ctx => up = ctx.ReadValue<float>();
        controls.Josh2.Up.canceled += ctx => up = 0f;

        controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
        controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;

    }




    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }

    // Start is called before the first frame update
    void Start()
    {
        pl2 = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ability = ability + UnityEngine.Random.Range(1, 4) - 1;
        originalColor = spriteRenderer.color;
        ability = 2;

    }
    void FlipSprite()
    {
        // Flip the sprite horizontally
        isFlipped2 = !isFlipped2;
        staticGunFliped2 = true;
        spriteRenderer.flipX = isFlipped2;
    }
    private IEnumerator ReverseControlsCoroutine()
    {
        reverseControls = true;
        yield return new WaitForSeconds(3f);
        reverseControls = false;  // Disable reverse controls after 5 seconds
    }
    private IEnumerator ReverseControlsCoroutine2()
    {
        reverseControls2 = true;
        yield return new WaitForSeconds(3f);
        reverseControls2 = false;  // Disable reverse controls after 5 seconds
    }

    private IEnumerator GravityReverse()
    {
        rb.gravityScale = -1;
        gravityReversed = true;
        yield return new WaitForSeconds(3f);
        rb.gravityScale = 1;
        gravityReversed = false;
    }

    private IEnumerator Invisible()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(5f);
        spriteRenderer.enabled = true;

    }
    private IEnumerator Invincible()
    {
        object1.SetActive(true);
        speed2 = speed2 / 1.6f;
        boxCollider.enabled = false;
        boxCollider2.enabled = false;
        invincible = true;
        spriteRenderer.color = Color.grey;
        
        yield return new WaitForSeconds(5f);
        invincible = false;
        object1.SetActive(false);
        speed2 = speed2 * 1.6f;
        boxCollider.enabled = true;
        boxCollider2.enabled = true;
        spriteRenderer.color = originalColor;


    }
    private IEnumerator bulletDirectionChanger()
    {
        yield return new WaitForSeconds(0.1f);
        bulletDirection = false;

    }
    private IEnumerator bigBoomerang2()
    {
        yield return new WaitForSeconds(0.2f);
        bigboomerang = true;
    }
    private IEnumerator blueRay()
    {
        for (int i = 0; i < 300; i++) // Loop 2500 times
        {
            blue = true;
            yield return new WaitForSeconds(0.01f); // Wait for 0.001 seconds
        }
    }




    // Update is called once per frame
    void Update()
    {
        



        if (IsGrounded() == true)
        {
            animator.SetBool("crouch", false);
            //animator.SetBool("jump", false);

        }
        if (timer1 != 0 )
        {
            timer1 = timer1 - 4;
        }
        if (timer2 != 0)
        {
            timer2--;
        }

        
        if (StaticScript.player2character == 4)
        {
                
            if ((Input.GetKeyDown(KeyCode.Alpha1)) && timer1 == 0)
            {
                timer1 = 3000;

                if (ability == 0)
                {
                    StartCoroutine(ReverseControlsCoroutine());
                }
                if (ability == 1)
                {
                    StartCoroutine(ReverseControlsCoroutine2());
                }
                if (ability == 2)
                {
                    bigboomerang = true;
                    StartCoroutine(bigBoomerang2());
                }
                if (ability == 3)
                {
                    StartCoroutine(GravityReverse());
                }
                if (ability == 4)
                {
                    StartCoroutine(Invisible());
                }
                if (ability == 5)
                {
                    bulletDirection = true;
                    StartCoroutine(bulletDirectionChanger());

                }
                if (ability == 6)
                {
                    StartCoroutine(Invincible());
                }
                if (ability == 7)
                {
                    StartCoroutine(blueRay());
                }
                if (ability == abilityCount)
                {
                    ability = 0;
                    ability = ability + UnityEngine.Random.Range(1, 3) - 1;

                }
                else if (ability == (abilityCount - 1))
                {
                    ability = ability + 1;

                }
                else
                {
                    ability++;
                    //ability = ability + UnityEngine.Random.Range(1, 3);

                }
            }
        }
        else if (StaticScript.player1character == 4)
        {
            if ((Input.GetKeyDown(KeyCode.Period)) && timer1 == 0)
            {
                timer1 = 3000;

                if (ability == 0)
                {
                    StartCoroutine(ReverseControlsCoroutine());
                }
                if (ability == 1)
                {
                    StartCoroutine(ReverseControlsCoroutine2());
                }
                if (ability == 2)
                {
                    bigboomerang = true;
                    StartCoroutine(bigBoomerang2());
                }
                if (ability == 3)
                {
                    StartCoroutine(GravityReverse());
                }
                if (ability == 4)
                {
                    StartCoroutine(Invisible());
                }
                if (ability == 5)
                {
                    bulletDirection = true;
                    StartCoroutine(bulletDirectionChanger());

                }
                if (ability == 6)
                {
                    StartCoroutine(Invincible());
                }
                if (ability == 7)
                {
                    StartCoroutine(blueRay());
                }
                if (ability == abilityCount)
                {
                    ability = 0;
                    ability = ability + UnityEngine.Random.Range(1, 3) - 1;

                }
                else if (ability == (abilityCount - 1))
                {
                    ability = ability + 1;

                }
                else
                {
                    ability++;
                    //ability = ability + UnityEngine.Random.Range(1, 3);

                }
            }
        }
        else if (StaticScript.player3character == 4)
        {
            if (attack2 == 1 && timer1 == 0)
            {
                timer1 = 3000;

                if (ability == 0)
                {
                    StartCoroutine(ReverseControlsCoroutine());
                }
                if (ability == 1)
                {
                    StartCoroutine(ReverseControlsCoroutine2());
                }
                if (ability == 2)
                {
                    bigboomerang = true;
                    StartCoroutine(bigBoomerang2());
                }
                if (ability == 3)
                {
                    StartCoroutine(GravityReverse());
                }
                if (ability == 4)
                {
                    StartCoroutine(Invisible());
                }
                if (ability == 5)
                {
                    bulletDirection = true;
                    StartCoroutine(bulletDirectionChanger());

                }
                if (ability == 6)
                {
                    StartCoroutine(Invincible());
                }
                if (ability == 7)
                {
                    StartCoroutine(blueRay());
                }
                if (ability == abilityCount)
                {
                    ability = 0;
                    ability = ability + UnityEngine.Random.Range(1, 3) - 1;

                }
                else if (ability == (abilityCount - 1))
                {
                    ability = ability + 1;

                }
                else
                {
                    ability++;
                    //ability = ability + UnityEngine.Random.Range(1, 3);

                }
            }
        }
    






        if (kill == true)
        {
            kill = false;
            jumping++;
            jumping2++;
        }
        horizontal = 0f;

        if (StaticScript.player2character == 4)
        {
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = reverseControls ? 1f : -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = reverseControls ? -1f : 1f;
            }


        }
        else if (StaticScript.player1character == 4)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal = reverseControls ? 1f : -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = reverseControls ? -1f : 1f;
            }
        }
        else if (StaticScript.player3character == 4)
        {
            if (move < 0)
            {
                horizontal = reverseControls ? 1f : -1f;
            }
            else if (move > 0)
            {
                horizontal = reverseControls ? -1f : 1f;
            }
        }




        if (horizontal > 0 && isFlipped2)
        {
            FlipSprite();
        }
        else if (horizontal < 0 && !isFlipped2)
        {
            FlipSprite();
        }


        animator.SetFloat("speed", Mathf.Abs(horizontal));

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


        if (StaticScript.player2character == 4)
        {
                
            if ((reverseControls2 ? Input.GetKeyDown(KeyCode.S) : Input.GetKeyDown(KeyCode.W)) && IsGrounded())
            {
                if (gravityReversed == true)
                {
                    animator.SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                }
                else
                {
                    animator.SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                }
            }
            if ((reverseControls2 ? Input.GetKeyDown(KeyCode.S) : Input.GetKeyDown(KeyCode.W)) && !IsGrounded() && jumping2 != 0)
            {
                if (gravityReversed == true)
                {
                    jumping2--;
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                }
                else
                {
                    jumping2--;
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                }

            }

            if ((reverseControls2 ? Input.GetKey(KeyCode.W) : Input.GetKey(KeyCode.S)) && IsGrounded())
            {
                animator.SetBool("crouch", true);
                speed = speed2/2;
                boxCollider.enabled = false;
                if (a)
                {
                    crouchNow2 = true;
                    a = false;
                }
                b = true;
            }
            else
            {
                animator.SetBool("crouch", false);
                speed = speed2;
                boxCollider.enabled = true;
                if (b)
                {
                    notcrouchNow2 = true;
                    b = false;
                }
                a = true;
            }
        }
        else if (StaticScript.player1character == 4)
        {
            if ((reverseControls2 ? Input.GetKeyDown(KeyCode.DownArrow) : Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
            {
                if (gravityReversed == true)
                {
                    animator.SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                }
                else
                {
                    animator.SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                }
            }
            if ((reverseControls2 ? Input.GetKeyDown(KeyCode.DownArrow) : Input.GetKeyDown(KeyCode.UpArrow)) && !IsGrounded() && jumping2 != 0)
            {
                if (gravityReversed == true)
                {
                    jumping2--;
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                }
                else
                {
                    jumping2--;
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                }

            }

            if ((reverseControls2 ? Input.GetKey(KeyCode.UpArrow) : Input.GetKey(KeyCode.DownArrow)) && IsGrounded())
            {
                animator.SetBool("crouch", true);
                speed = speed2/2;
                boxCollider.enabled = false;
                if (a)
                {
                    crouchNow2 = true;
                    a = false;
                }
                b = true;
            }
            else
            {
                animator.SetBool("crouch", false);
                speed = speed2;
                boxCollider.enabled = true;
                if (b)
                {
                    notcrouchNow2 = true;
                    b = false;
                }
                a = true;
            }
        }
        else if (StaticScript.player3character == 4)
        {
            if (reverseControls2 ? down > 0f : up > 0f && IsGrounded())
            {
                if (gravityReversed == true)
                {
                    animator.SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                }
                else
                {
                    animator.SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                }
            }
            if (reverseControls2 ? down > 0f : up > 0f && !IsGrounded() && jumping2 != 0)
            {
                if (gravityReversed == true)
                {
                    jumping2--;
                    rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
                }
                else
                {
                    jumping2--;
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                }

            }

            if (reverseControls2 ? up > 0f : down > 0f && IsGrounded())
            {
                animator.SetBool("crouch", true);
                speed = speed2/2;
                boxCollider.enabled = false;
                if (a)
                {
                    crouchNow2 = true;
                    a = false;
                }
                b = true;
            }
            else
            {
                animator.SetBool("crouch", false);
                speed = speed2;
                boxCollider.enabled = true;
                if (b)
                {
                    notcrouchNow2 = true;
                    b = false;
                }
                a = true;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetBool("jumping", false);
            jumping2 = jumping;

        }
    }

    private bool IsGrounded()
    {
        if (gravityReversed == true)
        {
            RaycastHit2D hits = Physics2D.Raycast(ceilingCheck.position, Vector2.up, 0.1f, groundlayer);
            bool isTouchingCeiling = false;
            if (hits.collider != null)
            {
                isTouchingCeiling = true;
            }
            else
            {
                isTouchingCeiling = false;
            }
            return isTouchingCeiling;
        }
        //return Physics2D.OverlapCircle(groundCheck.position, radius, groundlayer);
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
        if (collision.gameObject.CompareTag("orb2"))
        {
            Destroy(collision.gameObject);
            orbspawner.a = true;
            timer1 = 0;
        }
    }
    
}
