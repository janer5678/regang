using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    public GameObject character;
    public Rigidbody2D rb;
    public float speed;
    public float jump_force = 8f;
    public float radius = 3f;


    [SerializeField] private Transform groundcheck;

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private GameObject groundCheckMiddle;
    [SerializeField] private GameObject groundCheckLeft;
    [SerializeField] private GameObject groundCheckRight;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Animator animator;



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



        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Movement", true);
            character.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Movement", true);
            character.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        } else
        {
            animator.SetBool("Movement", false);
        }

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            animator.SetBool("IsGrounded", false);
            animator.SetBool("PreJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        } else if (isGrounded)
        {
            animator.SetBool("IsGrounded", true);
            animator.SetBool("PreJumping", false);
        }

    }

}
