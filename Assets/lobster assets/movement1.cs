using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class movement1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public Transform castleft;
    public Transform castright;
    private bool canjump;
    private Animator animator;
    private float timer;
    private bool dontanimationmove;

    private bool changed;
    public GameObject Square;
    private bool switch1;
    Josh2Controls controls;

    public LayerMask ground;
    float move;
    float up;
    float attack1;

    private void Awake()
    {
        controls = new Josh2Controls();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Up.performed += ctx => jump3();

        controls.Josh2.Attack1.performed += ctx => attack3();

    }

    void attack3()
    {
        if (StaticScript.player3character == 9)
        {
            
            {
                Square.SetActive(true);
                //animator.SetTrigger("New Trigger");
                animator.Play("attack");
                dontanimationmove = true;
                timer = 0.3f;
            }
        }
    }

    void jump3()
    {
        if (StaticScript.player3character == 9)
        {
            if (canjump)
            {
                rb.velocity = rb.velocity + Vector2.up * 7;
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }

    void squaretransformleft()
    {
        Square.transform.position = new Vector2(Square.transform.position.x - 0.4f, Square.transform.position.y);

    }
    void squaretransformright()
    {
        Square.transform.position = new Vector2(Square.transform.position.x + 0.4f, Square.transform.position.y);

    }
    void Update()
    {
        if (StaticScript.player1character == 9)
        {
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                Square.SetActive(true);
                //animator.SetTrigger("New Trigger");
                animator.Play("attack");
                dontanimationmove = true;
                timer = 0.3f;
            }
        }
        else if (StaticScript.player2character == 9)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Square.SetActive(true);
                //animator.SetTrigger("New Trigger");
                animator.Play("attack");
                dontanimationmove = true;
                timer = 0.3f;
            }
        }







        if (timer < 0)
        {
            Square.SetActive(false);


        }
        if (StaticScript.player1character == 9)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                sp.flipX = true;

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 1f);

                }
                if (switch1 == false)
                {

                    squaretransformleft();
                    switch1 = true;
                }

                changed = true;
                transform.position = new Vector2(transform.position.x - Time.deltaTime * 7, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                if (changed && switch1)
                {
                    switch1 = false;
                    squaretransformright();

                }

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 1f);

                }



                sp.flipX = false;

                transform.position = new Vector2(transform.position.x + Time.deltaTime * 7, transform.position.y);

            }
            else
            {

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 0f);

                }

            }
        }
        else if (StaticScript.player2character == 9)
        {
            if (Input.GetKey(KeyCode.A))
            {
                sp.flipX = true;

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 1f);

                }
                if (switch1 == false)
                {
                    Square.transform.position = new Vector2(Square.transform.position.x - 0.4f, Square.transform.position.y);
                    switch1 = true;
                }

                changed = true;
                transform.position = new Vector2(transform.position.x - Time.deltaTime * 7, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {

                if (changed && switch1)
                {
                    switch1 = false;
                    Square.transform.position = new Vector2(Square.transform.position.x + 0.4f, Square.transform.position.y);

                }

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 1f);

                }



                sp.flipX = false;

                transform.position = new Vector2(transform.position.x + Time.deltaTime * 7, transform.position.y);

            }
            else
            {

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 0f);

                }

            }
        }
        else if (StaticScript.player3character == 9)
        {
            if (move < 0)
            {
                sp.flipX = true;

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 1f);

                }
                if (switch1 == false)
                {
                    Square.transform.position = new Vector2(Square.transform.position.x - 0.4f, Square.transform.position.y);
                    switch1 = true;
                }

                changed = true;
                transform.position = new Vector2(transform.position.x - Time.deltaTime * 7, transform.position.y);
            }
            else if (move > 0)
            {

                if (changed && switch1)
                {
                    switch1 = false;
                    Square.transform.position = new Vector2(Square.transform.position.x + 0.4f, Square.transform.position.y);

                }

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 1f);

                }



                sp.flipX = false;

                transform.position = new Vector2(transform.position.x + Time.deltaTime * 7, transform.position.y);

            }
            else
            {

                if (dontanimationmove == false)
                {
                    animator.SetFloat("speed", 0f);

                }

            }
        }

        if (StaticScript.player1character == 9)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && canjump)
            {
                rb.velocity = rb.velocity + Vector2.up * 7;
            }
        }
        else if (StaticScript.player2character == 9)
        {
            if (Input.GetKeyDown(KeyCode.W) && canjump)
            {
                rb.velocity = rb.velocity + Vector2.up * 7;
            }
        }


        RaycastHit2D hit = Physics2D.Raycast(castleft.transform.position, -Vector2.up, 0.1f, ground);
        RaycastHit2D hit2 = Physics2D.Raycast(castright.transform.position, -Vector2.up, 0.1f, ground);

        if (hit)
        {
            canjump = true;
        }
        else if (hit2)
        {
            canjump = true;

        }
        else
        {
            canjump = false;
        }

        timer = timer - Time.deltaTime;
        
        
            
        dontanimationmove = false;

    

    }
}
