using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MaoMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool left;

    public float cool_down;
    private float speed = 5;
    public float jump_force = 8f;
    public float radius = 3f;
    private SpriteRenderer sp;
    private BoxCollider2D bc;


    public GameObject mao;

    private bool noGrav;
    private bool duck;

    bool fliped;
   

    [SerializeField] private Transform Raycast1;

    [SerializeField] private Transform Raycast2;

    public LayerMask groundLayer;

    Animator animator;

    private bool switcher;

    float timer ;

    bool onground;

    bool changed;

    float cooldown2;

    float downtimer;
    float move;
    float up;
    float attack1;
    Josh2Controls controls;
    float attack2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        sp = GetComponent<SpriteRenderer>();

        bc = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onground = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onground = false;
        }
    }

    private void Awake()
    {
        controls = new Josh2Controls();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Up.performed += ctx => up = ctx.ReadValue<float>();
        controls.Josh2.Up.canceled += ctx => up = 0f;

        controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
        controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;


    }
    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }

    // Update is called once per frame
    void Update()
    {

        if (StaticScript.player1character == 6)
        {

            if (Input.GetKey(KeyCode.Period) && downtimer < 0)
            {
                

                animator.SetBool("attack", true);

                for (int i = 0; i < 10; i++)
                {
                    Instantiate(mao, transform.position, Quaternion.identity);
                }


                downtimer = 8;
            }
        }
        else if (StaticScript.player2character == 6)
        {
            if (Input.GetKey(KeyCode.Alpha1) && downtimer < 0)
            {
                

                animator.SetBool("attack", true);

                for (int i = 0; i < 20; i++)
                {
                    Instantiate(mao, transform.position, Quaternion.identity);
                }


                downtimer = 8;
            }
        }

        else if (StaticScript.player3character == 6)
        {
            if (attack2 > 0 && downtimer < 0)
            {


                animator.SetBool("attack", true);

                for (int i = 0; i < 20; i++)
                {
                    Instantiate(mao, transform.position, Quaternion.identity);
                }


                downtimer = 8;
            }
        }



        downtimer = downtimer - Time.deltaTime;

        if (StaticScript.player1character == 6)
        {
            if (Input.GetKey(KeyCode.Slash))
            {
                animator.SetBool("attack", true);
                if (cool_down < 0)
                {
                    Instantiate(mao, transform.position, Quaternion.identity);
                    cool_down = 0.6f;
                }
            }
            else
            {
                animator.SetBool("attack", false);

            }
        }
        else if (StaticScript.player2character == 6)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                animator.SetBool("attack", true);
                if (cool_down < 0)
                {
                    Instantiate(mao, transform.position, Quaternion.identity);
                    cool_down = 0.6f;
                }
            }
            else
            {
                animator.SetBool("attack", false);

            }
        }
        else if (StaticScript.player3character == 6)
        {
            if (attack1 > 0)
            {
                animator.SetBool("attack", true);
                if (cool_down < 0)
                {
                    Instantiate(mao, transform.position, Quaternion.identity);
                    cool_down = 0.6f;
                }
            }
            else
            {
                animator.SetBool("attack", false);

            }
        }

        cool_down -= Time.deltaTime;


        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    duck = true;
        //    animator.SetFloat("duck", 1);
        //    bc.size = new Vector2(0.17f, 0.05f);
        //    bc.offset = new Vector2(0.038f, -0.12f);


        //}
        //else
        //{
        //    if (duck)
        //    {
        //        animator.SetFloat("duck", 0);
        //        bc.size = new Vector2(0.169f,0.11f);
        //        bc.offset = new Vector2(0.038f, -0.105f);
        //    }
        //    duck = false;
        //}






        if (StaticScript.player1character == 6)
        {

            if ((Input.GetKey(KeyCode.RightArrow)))
            {
                changed = true;
                sp.flipX = true;
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                animator.SetFloat("Speed", 1);
                left = false;

                if (switcher == false)
                {
                    switcher = true;

                    bc.offset = new Vector2(bc.offset.x - 0.07f, bc.offset.y);


                }

            }
            else if ((Input.GetKey(KeyCode.LeftArrow)))
            {

                sp.flipX = false;
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                animator.SetFloat("Speed", 1);
                left = true;

                if (switcher == true && changed == true)
                {
                    switcher = false;
                    bc.offset = new Vector2(bc.offset.x + 0.07f, bc.offset.y);

                }


            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
        else if (StaticScript.player2character == 6)
        {

            if ((Input.GetKey(KeyCode.D)))
            {
                changed = true;
                sp.flipX = true;
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                animator.SetFloat("Speed", 1);
                left = false;

                if (switcher == false)
                {
                    switcher = true;

                    bc.offset = new Vector2(bc.offset.x - 0.07f, bc.offset.y);


                }

            }
            else if ((Input.GetKey(KeyCode.A)))
            {

                sp.flipX = false;
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                animator.SetFloat("Speed", 1);
                left = true;

                if (switcher == true && changed == true)
                {
                    switcher = false;
                    bc.offset = new Vector2(bc.offset.x + 0.07f, bc.offset.y);

                }


            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
        else if (StaticScript.player3character == 6)
        {

            if (move > 0)
            {
                changed = true;
                sp.flipX = true;
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                animator.SetFloat("Speed", 1);
                left = false;

                if (switcher == false)
                {
                    switcher = true;

                    bc.offset = new Vector2(bc.offset.x - 0.07f, bc.offset.y);


                }

            }
            else if (move < 0 )
            {

                sp.flipX = false;
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                animator.SetFloat("Speed", 1);
                left = true;

                if (switcher == true && changed == true)
                {
                    switcher = false;
                    bc.offset = new Vector2(bc.offset.x + 0.07f, bc.offset.y);

                }


            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }


        if (cooldown2 < 0)
        {


            if (StaticScript.player1character == 6)
            {
                if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && fliped == false)
                {
                    rb.gravityScale = -3;
                    sp.flipY = true;
                    fliped = true;
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
                    bc.offset = new Vector2(bc.offset.x, bc.offset.y + 0.22f);
                    cooldown2 = 0.5f;

                }
                else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && fliped == true)
                {
                    rb.gravityScale = 3;
                    sp.flipY = false;
                    fliped = false;
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);

                    bc.offset = new Vector2(bc.offset.x, bc.offset.y - 0.22f);
                    cooldown2 = 0.5f;
                }
            }
            else if (StaticScript.player2character == 6)
            {
                if ((Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.S))) && fliped == false)
                {
                    rb.gravityScale = -3;
                    sp.flipY = true;
                    fliped = true;
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
                    bc.offset = new Vector2(bc.offset.x, bc.offset.y + 0.22f);
                    cooldown2 = 0.5f;

                }
                else if ((Input.GetKeyDown(KeyCode.W) ||(Input.GetKeyDown(KeyCode.S))) && fliped == true)
                {
                    rb.gravityScale = 3;
                    sp.flipY = false;
                    fliped = false;
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);

                    bc.offset = new Vector2(bc.offset.x, bc.offset.y - 0.22f);
                    cooldown2 = 0.5f;
                }
            }
            else if (StaticScript.player3character == 6)
            {
                if (up > 0 && fliped == false)
                {
                    rb.gravityScale = -3;
                    sp.flipY = true;
                    fliped = true;
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
                    bc.offset = new Vector2(bc.offset.x, bc.offset.y + 0.22f);
                    cooldown2 = 0.5f;

                }
                else if (up > 0 && fliped == true)
                {
                    rb.gravityScale = 3;
                    sp.flipY = false;
                    fliped = false;
                    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);

                    bc.offset = new Vector2(bc.offset.x, bc.offset.y - 0.22f);
                    cooldown2 = 0.5f;
                }
            }

        }

        cooldown2 = cooldown2 - Time.deltaTime;








    }



}
