using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class awesome_character_movement : MonoBehaviour
{
    public GameObject character;
    public Sprite image;
    public float speed;
    public float cum;
    public float jump_force = 8f;
    public float radius = 0.1f;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Sprite sprite;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;

    public GameObject projectilePrefab; // Reference to your projectile prefab
    public int maxProjectiles = 10; // Maximum number of projectiles allowed

    private List<GameObject> activeProjectiles = new List<GameObject>();

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private float real_speed;
    private bool hiden;
    private Vector2 direction;

    Josh2Controls controls;
    float move;
    float down;
    float up;
    float attack1;
    float attack2;

    // Start is called before the first frame update

    private void Awake()
    {
        controls = new Josh2Controls();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Down.performed += ctx => down = ctx.ReadValue<float>();
        controls.Josh2.Down.canceled += ctx => down = 0f;

        controls.Josh2.Up.performed += ctx => up = ctx.ReadValue<float>();
        controls.Josh2.Up.canceled += ctx => up = 0f;


        controls.Josh2.Attack1.performed += ctx => attack13();

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;




    }
    void attack13()
    {

        if (StaticScript.player3character == 8)
        {
            if (!hiden)
            {
                BulletCreate();
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
        real_speed = speed;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hiden = false;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (StaticScript.player2character == 8)
        {
            if (!Input.GetKey(KeyCode.S) && (!hiden))
            {
                animator.SetFloat("squat", 0f);
                real_speed = speed;

            }
        }
        else if (StaticScript.player1character == 8)
        {
            if (!Input.GetKey(KeyCode.DownArrow) && (!hiden))
            {
                animator.SetFloat("squat", 0f);
                real_speed = speed;

            }
        }
        else if (StaticScript.player3character == 8)
        {
            if (down == 0 && (!hiden))
            {
                animator.SetFloat("squat", 0f);
                real_speed = speed;

            }
        }



        if (StaticScript.player2character == 8)
        {

            if (Input.GetKey(KeyCode.D) && (!hiden))
            {
                character.transform.Translate(new Vector3(real_speed * Time.deltaTime * 500, 0, 0));
                animator.SetFloat("ishowspeedf", 1f);
                spriteRenderer.flipX = false;
                direction = new Vector2(cum, 0f);

            }
            else if (Input.GetKey(KeyCode.A) && (!hiden))
            {
                character.transform.Translate(new Vector3(-real_speed * Time.deltaTime * 500, 0, 0));
                animator.SetFloat("ishowspeedf", 1f);
                spriteRenderer.flipX = true;
                direction = new Vector2(-cum, 0f);

            }
            else
            {
                animator.SetFloat("ishowspeedf", 0f);
            }
        }
        else if (StaticScript.player1character == 8)
        {
            if (Input.GetKey(KeyCode.RightArrow) && (!hiden))
            {
                character.transform.Translate(new Vector3(real_speed * Time.deltaTime * 500, 0, 0));
                animator.SetFloat("ishowspeedf", 1f);
                spriteRenderer.flipX = false;
                direction = new Vector2(cum, 0f);

            }
            else if (Input.GetKey(KeyCode.LeftArrow) && (!hiden))
            {
                character.transform.Translate(new Vector3(-real_speed * Time.deltaTime * 500, 0, 0));
                animator.SetFloat("ishowspeedf", 1f);
                spriteRenderer.flipX = true;
                direction = new Vector2(-cum, 0f);

            }
            else
            {
                animator.SetFloat("ishowspeedf", 0f);
            }
        }
        else if (StaticScript.player3character == 8)
        {
            if (move > 0 && (!hiden))
            {
                character.transform.Translate(new Vector3(real_speed * Time.deltaTime * 500, 0, 0));
                animator.SetFloat("ishowspeedf", 1f);
                spriteRenderer.flipX = false;
                direction = new Vector2(cum, 0f);

            }
            else if (move < 0 && (!hiden))
            {
                character.transform.Translate(new Vector3(-real_speed * Time.deltaTime * 500, 0, 0));
                animator.SetFloat("ishowspeedf", 1f);
                spriteRenderer.flipX = true;
                direction = new Vector2(-cum, 0f);

            }
            else
            {
                animator.SetFloat("ishowspeedf", 0f);
            }
        }

        if (StaticScript.player2character == 8)
        {
            if (Input.GetKey(KeyCode.S) && (!hiden))
            {
                rb.velocity = new Vector2(rb.velocity.x, -2 * jump_force);
                animator.SetFloat("squat", 1f);
                real_speed = speed / 5;
                direction = new Vector2(0f, -cum);

                bc.size = new Vector2(0.47f, 0.3f);

                bc.offset = new Vector2(-0.04f, -0.046f);
            }
            else
            {
                bc.size = new Vector2(0.47f, 0.6f);

                bc.offset = new Vector2(-0.04f, 0.086f);
            }
        }
        else if (StaticScript.player1character == 8)
        {
            if (Input.GetKey(KeyCode.DownArrow) && (!hiden))
            {
                rb.velocity = new Vector2(rb.velocity.x, -2 * jump_force);
                animator.SetFloat("squat", 1f);
                real_speed = speed / 5;
                direction = new Vector2(0f, -cum);

                bc.size = new Vector2(0.47f, 0.3f);
                bc.offset = new Vector2(-0.04f, -0.046f);
            }
            else
            {
                bc.size = new Vector2(0.47f, 0.6f);

                bc.offset = new Vector2(-0.04f, 0.086f);
            }
        }
        else if (StaticScript.player3character == 8)
        {
            if (down > 0 && (!hiden))
            {
                rb.velocity = new Vector2(rb.velocity.x, -2 * jump_force);
                animator.SetFloat("squat", 1f);
                real_speed = speed / 5;
                direction = new Vector2(0f, -cum);
                bc.size = new Vector2( 0.47f, 0.3f);
                bc.offset = new Vector2(-0.04f, -0.046f);
            }
            else
            {
                bc.size = new Vector2(0.47f, 0.6f);
                bc.offset = new Vector2(-0.04f, 0.086f);
            }
        }


        if (StaticScript.player2character == 8)
        {
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded() && !hiden)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump_force);
                animator.SetFloat("jumpin", 1f);
                direction = new Vector2(0f, cum);
            }
        }
        else if (StaticScript.player1character == 8)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded() && !hiden)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump_force);
                animator.SetFloat("jumpin", 1f);
                direction = new Vector2(0f, cum);
            }
        }
        else if (StaticScript.player3character == 8)
        {
            if (up > 0 && IsGrounded() && !hiden)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump_force);
                animator.SetFloat("jumpin", 1f);
                direction = new Vector2(0f, cum);
            }
        }

        if (StaticScript.player2character == 8)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                animator.SetFloat("hiden", 1f);
                hiden = true;


            }
            else
            {
                animator.SetFloat("hiden", 0f);
                hiden = false;
            }
        }
        else if (StaticScript.player1character == 8)
        {
            if (Input.GetKey(KeyCode.Period))
            {
                animator.SetFloat("hiden", 1f);
                hiden = true;


            }
            else
            {
                animator.SetFloat("hiden", 0f);
                hiden = false;
            }
        }
        else if (StaticScript.player3character == 8)
        {
            if (attack2 > 0)
            {
                animator.SetFloat("hiden", 1f);
                hiden = true;


            }
            else
            {
                animator.SetFloat("hiden", 0f);
                hiden = false;
            }
        }

        if (StaticScript.player2character == 8)
        {
            if ((Input.GetKeyDown(KeyCode.Q) && !hiden))
            {
                BulletCreate();
            }
        }
        else if (StaticScript.player1character == 8)
        {
            if ((Input.GetKeyDown(KeyCode.Slash) && !hiden))
            {
                BulletCreate();
            }
        }





    }

    void BulletCreate()
    {
        GameObject bullet = new GameObject();
        bullet.AddComponent<SpriteRenderer>();
        bullet.GetComponent<SpriteRenderer>().sprite = sprite;
        bullet.AddComponent<Bullet>();
        bullet.GetComponent<Bullet>().direction = direction;
        bullet.AddComponent<Rigidbody2D>();
        bullet.AddComponent<BoxCollider2D>();
        bullet.transform.Translate(this.transform.position);
        activeProjectiles.Add(bullet);

        // Check if the list exceeds the maximum allowed projectiles
        if (activeProjectiles.Count > maxProjectiles)
        {
            // Destroy the oldest projectile
            Destroy(activeProjectiles[0]);
            // Remove it from the list
            activeProjectiles.RemoveAt(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetFloat("jumpin", 0f);
        }
        
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, radius, groundlayer); 
    }
}


