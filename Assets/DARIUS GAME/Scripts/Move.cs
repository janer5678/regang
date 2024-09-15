using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public bool onTheGround;
    public float groundDistance;
    public LayerMask groundLayer;

    public bool canDodge = true;
    public bool canJump = true;
    public bool toRight, toLeft;
    public bool dead, stop;
    public bool protect;
    public bool isDodge;
    public float speed = 1.0f;
    public float jumpHeight;
    public GameObject body;
    Animator anime;
    public Rigidbody2D playerBody;
    public Image hp;
    public float currentHP, maxHP, bodyDamage, bigLegDamge, smallLegDamage;
    public Collider2D bossBody, bossBigLeft, bossBigRight, bossSmallLeft, bossSmallRight, player;
    public SpriteRenderer bodySprite, leftSprite, rightSprite;
    // Start is called before the first frame update

    private SpriteRenderer SpriteRenderer;

    DariusControls controls;

    float move;
    float down;
    float up;

    void Awake()
    {
        controls = new DariusControls();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Down.performed += ctx => down3();

        controls.Josh2.Up.performed += ctx => jump3();
    }

    void jump3()
    {
        if (StaticScript.player3character == 2)
        {
            if (onTheGround == true & canJump == true)
            {
                anime.SetBool("animeSpace", true);
                playerBody.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                onTheGround = false;
            }
            else
            {
                anime.SetBool("animeSpace", false);
            }
        }
    }

    void down3()
    {
        if (canDodge == true)
        {
            if (StaticScript.player3character == 2)
            {

                {

                    SpriteRenderer SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

                    SpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);



                    canDodge = false;
                    canJump = false;
                    player.enabled = false;
                    Invoke("DodgeCooldown", 0.35f);
                    Invoke("DodgeCooldown1", 1f);
                    anime.SetBool("animeRightOrShift", true);
                    playerBody.gravityScale = 0f;
                    playerBody.velocity = Vector3.zero;
                    if (toRight == true)
                    {
                        playerBody.velocity = new Vector2(playerBody.velocity.x + 6, playerBody.velocity.y);
                    }
                    else if (toLeft == true)
                    {
                        playerBody.velocity = new Vector2(playerBody.velocity.x - 6, playerBody.velocity.y);

                    }
                }
            }
        }
            
    }


    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }
    void Start()
    {



        anime = body.GetComponent<Animator>();
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        onTheGround = true;
        toRight = true;
        toLeft = false;
        canDodge = true;
        dead = stop = false;
        protect = false;
        isDodge = false;

        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {



        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, groundLayer);



        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.05f, transform.position.y), Vector2.down, 0.4f, groundLayer);



        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 0.05f, transform.position.y), Vector2.down, 0.4f, groundLayer);

        if (hit.collider != null)
        {
            onTheGround = true;
        }
        else if (hit2.collider != null)
        {
            onTheGround = true;
        }
        else if (hit3.collider != null)
        {
            onTheGround = true;
        }
        else
        {
            onTheGround = false;
        }



        if (!dead)
        {
            GroundCheck();

            if (StaticScript.player2character == 2)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    anime.SetBool("animeD", true);
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                    toRight = true;
                    toLeft = false;
                }
                else
                {
                    anime.SetBool("animeD", false);
                }
            }
            else if (StaticScript.player1character == 2)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    anime.SetBool("animeD", true);
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                    toRight = true;
                    toLeft = false;
                }
                else
                {
                    anime.SetBool("animeD", false);
                }
            }
            else if (StaticScript.player3character == 2)
            {
                if (move > 0)
                {
                    anime.SetBool("animeD", true);
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                    toRight = true;
                    toLeft = false;
                }
                else
                {
                    anime.SetBool("animeD", false);
                }
            }



            if (StaticScript.player2character == 2)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    anime.SetBool("animeA", true);
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                    toLeft = true;
                    toRight = false;
                }
                else
                {
                    anime.SetBool("animeA", false);
                }
            }
            else if (StaticScript.player1character == 2)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    anime.SetBool("animeA", true);
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                    toLeft = true;
                    toRight = false;
                }
                else
                {
                    anime.SetBool("animeA", false);
                }
            }
            else if (StaticScript.player3character == 2)
            {
                if (move < 0)
                {
                    anime.SetBool("animeA", true);
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                    toLeft = true;
                    toRight = false;
                }
                else
                {
                    anime.SetBool("animeA", false);
                }
            }




            if (StaticScript.player2character == 2)
            {
                if (Input.GetKeyDown(KeyCode.W) & onTheGround == true & canJump == true)
                {
                    anime.SetBool("animeSpace", true);
                    playerBody.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    onTheGround = false;
                }
                else
                {
                    anime.SetBool("animeSpace", false);
                }
            }
            else if (StaticScript.player1character == 2)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) & onTheGround == true & canJump == true)
                {
                    anime.SetBool("animeSpace", true);
                    playerBody.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    onTheGround = false;
                }
                else
                {
                    anime.SetBool("animeSpace", false);
                }
            }



            if (canDodge == true)
            {
                if (StaticScript.player2character == 2)
                {

                    if (Input.GetKeyDown(KeyCode.S))
                    {

                        SpriteRenderer SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

                        SpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);



                        canDodge = false;
                        canJump = false;
                        player.enabled = false;
                        Invoke("DodgeCooldown", 0.35f);
                        Invoke("DodgeCooldown1", 1f);
                        anime.SetBool("animeRightOrShift", true);
                        playerBody.gravityScale = 0f;
                        playerBody.velocity = Vector3.zero;
                        if (toRight == true)
                        {
                            playerBody.velocity = new Vector2(playerBody.velocity.x + 6, playerBody.velocity.y);
                        }
                        else if (toLeft == true)
                        {
                            playerBody.velocity = new Vector2(playerBody.velocity.x - 6, playerBody.velocity.y);

                        }
                    }
                }
                else if (StaticScript.player1character == 2)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {

                        SpriteRenderer SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

                        SpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);



                        canDodge = false;
                        canJump = false;
                        player.enabled = false;
                        Invoke("DodgeCooldown", 0.35f);
                        Invoke("DodgeCooldown1", 1f);
                        anime.SetBool("animeRightOrShift", true);
                        playerBody.gravityScale = 0f;
                        playerBody.velocity = Vector3.zero;
                        if (toRight == true)
                        {
                            playerBody.velocity = new Vector2(playerBody.velocity.x + 6, playerBody.velocity.y);
                        }
                        else if (toLeft == true)
                        {
                            playerBody.velocity = new Vector2(playerBody.velocity.x - 6, playerBody.velocity.y);

                        }
                    }
                }


            }


        }


    }


    void DodgeCooldown()
    {
        anime.SetBool("animeRightOrShift", false);
        SpriteRenderer SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        playerBody.gravityScale = 3f;
        canJump = true;
        player.enabled = true;

        playerBody.velocity = new Vector2(0f, 0f);
        print("hello");
    }

    void DodgeCooldown1()
    {
        canDodge = true;


    }


    void GroundCheck()
    {








    }
}
