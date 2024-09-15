using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject character;
    public Rigidbody2D rb;
    public float speed;
    public float jump_force = 8f;
    public float radius = 3f;

    DariusControls1 controls;
    float move;
    float up;

    public static bool leftdir;


    [SerializeField] private Transform groundcheck;

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private GameObject groundCheckMiddle;
    [SerializeField] private GameObject groundCheckLeft;
    [SerializeField] private GameObject groundCheckRight;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        controls = new DariusControls1();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Up.performed += ctx => up = ctx.ReadValue<float>();
        controls.Josh2.Up.canceled += ctx => up = 0f;


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
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D groundHitMiddle = Physics2D.Raycast(groundCheckMiddle.transform.position, -Vector2.up, 0.1f, groundlayer);
        RaycastHit2D groundHitLeft = Physics2D.Raycast(groundCheckLeft.transform.position, -Vector2.up, 0.1f, groundlayer);
        RaycastHit2D groundHitRight = Physics2D.Raycast(groundCheckRight.transform.position, -Vector2.up, 0.1f, groundlayer);


        if (groundHitMiddle || groundHitLeft || groundHitRight)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }


        if (StaticScript.player1character == 5)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("Movement", true);
                character.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                _bullet.transform.position = character.transform.position + new Vector3(0.55f, 0.0f, 0.0f);
                leftdir = false;




            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool("Movement", true);
                character.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                _bullet.transform.position = character.transform.position + new Vector3(-0.55f, 0.0f, 0.0f);
                leftdir = true;
            }
            else
            {
                animator.SetBool("Movement", false);
            }
        }
        else if (StaticScript.player2character == 5)
        {
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Movement", true);
                character.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                _bullet.transform.position = character.transform.position + new Vector3(0.55f, 0.0f, 0.0f);
                leftdir = false;




            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Movement", true);
                character.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                _bullet.transform.position = character.transform.position + new Vector3(-0.55f, 0.0f, 0.0f);
                leftdir = true;
            }
            else
            {
                animator.SetBool("Movement", false);
            }
        }
        else if (StaticScript.player3character == 5)
        {
            if (move > 0)
            {
                animator.SetBool("Movement", true);
                character.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                _bullet.transform.position = character.transform.position + new Vector3(0.55f, 0.0f, 0.0f);
                leftdir = false;




            }
            else if (move < 0)
            {
                animator.SetBool("Movement", true);
                character.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                _bullet.transform.position = character.transform.position + new Vector3(-0.55f, 0.0f, 0.0f);
                leftdir = true;
            }
            else
            {
                animator.SetBool("Movement", false);
            }
        }

        if (StaticScript.player1character == 5)
        {
            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                animator.SetBool("IsGrounded", false);
                animator.SetBool("PreJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jump_force);
            }
            else if (isGrounded)
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("PreJumping", false);
            }
        }
        else if (StaticScript.player2character == 5)
        {
            if (Input.GetKey(KeyCode.W) && isGrounded)
            {
                animator.SetBool("IsGrounded", false);
                animator.SetBool("PreJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jump_force);
            }
            else if (isGrounded)
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("PreJumping", false);
            }
        }
        else if (StaticScript.player3character == 5)
        {
            if (up > 0 && isGrounded)
            {
                animator.SetBool("IsGrounded", false);
                animator.SetBool("PreJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jump_force);
            }
            else if (isGrounded)
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("PreJumping", false);
            }
        }



    }
}
