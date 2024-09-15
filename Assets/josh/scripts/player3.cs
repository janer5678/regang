using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class player3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed = 0f;
    public float jumpingPower = 0f;
    public float speedy = 3f;
    public float jumpy = 6f;
    public static int hi = 0;
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
    public static float timer1 = 0;
    public static float timer2 = 0;
    public static float timer3 = 0;
    public static int shield = 1;
    public static int shieldmax = 1;
    public static bool invincible = false;
    public GameObject object1;
    public static GameObject pl3;

    Josh3Controls controls;
    float move;
    float up;
    float attack1;
    float attack2;
    float down;
    // Start is called before the first frame update

    private void Awake()
    {
        controls = new Josh3Controls();

        controls.Josh2.Movement.performed += ctx => move = ctx.ReadValue<float>();
        controls.Josh2.Movement.canceled += ctx => move = 0f;

        controls.Josh2.Up.performed += ctx => up = ctx.ReadValue<float>();
        controls.Josh2.Up.canceled += ctx => up = 0f;

        controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
        controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;

        controls.Josh2.Down.performed += ctx => down = ctx.ReadValue<float>();
        controls.Josh2.Down.canceled += ctx => down = 0f;
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

        pl3 = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2.enabled = false;
        speed = speedy;
        jumpingPower = jumpy;

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
        object1.SetActive(true);
        print(shield);
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
            timer1 = timer1 - (1 * Time.deltaTime);
        }
        if (timer2 != 0)
        {
            timer2 = timer2 - (1 * Time.deltaTime);
        }
        if (timer2 < 0)
        {
            timer2 = 0;
        }
        if (timer1 < 0)
        {
            timer1 = 0;
        }
        if (timer3 != 0)
        {
            timer3 = timer3 - (1 * Time.deltaTime);
        }
        if (timer3 < 0)
        {
            timer3 = 0;
        }

        if (StaticScript.player1character == 7)
        {
            if (Input.GetKey(KeyCode.Slash) && timer1 == 0)
            {
                timer1 = 14 - shieldmax;
                StartCoroutine(ability1());
            }
        }
        else if (StaticScript.player2character == 7)
        {
            if (Input.GetKey(KeyCode.Q) && timer1 == 0)
            {
                timer1 = 14 - shieldmax;
                StartCoroutine(ability1());
            }
        }
        else if (StaticScript.player3character == 7)
        {

            if (attack1 > 0 && timer1 == 0)
            {
                timer1 = 14 - shieldmax;
                StartCoroutine(ability1());
            }

        }



        if (StaticScript.player1character == 7)
        {
            if (Input.GetKey(KeyCode.Period) && timer2 == 0)
            {
                timer2 = 14 - shieldmax;
                StartCoroutine(ability2());

            }
        }
        else if (StaticScript.player2character == 7)
        {
            if (Input.GetKey(KeyCode.Alpha1) && timer2 == 0)
            {
                timer2 = 14 - shieldmax;
                StartCoroutine(ability2());

            }
        }
        else if (StaticScript.player3character == 7)
        {
            if (attack2 > 0 && timer2 == 0)
            {
                timer2 = 14 - shieldmax;
                StartCoroutine(ability2());
            }
        }






        if(StaticScript.player1character == 7)
        {
            if (Input.GetKey(KeyCode.DownArrow)&&timer3==0)
            {
                if(invincible == true)
                {
                    shieldmax++;
                }
                float randomValue = Random.value;

                if (randomValue <= 0.8f)
                {
                    shieldmax++;
                }
                randomValue = Random.value;
                if (randomValue <= 0.4f)
                {
                    shieldmax--;
                }
                timer3 = 4;
            }
        }
        else if (StaticScript.player2character == 7)
        {
            if (Input.GetKey(KeyCode.S) && timer3==0)
            {
                if (invincible == true)
                {
                    shieldmax++;
                }
                float randomValue = Random.value;
                if (randomValue <= 0.8f)
                {
                    shieldmax++;
                }
                randomValue = Random.value;
                if (randomValue <= 0.4f)
                {
                    shieldmax--;
                }
                timer3 = 4 - shieldmax/50;
            }
        }
        else if (StaticScript.player3character == 7)
        {
            if (down > 0 && timer3 == 0)
            {
                if (invincible == true)
                {
                    shieldmax++;
                }
                float randomValue = Random.value;

                if (randomValue <= 0.8f)
                {
                    shieldmax++;
                }
                randomValue = Random.value;
                if (randomValue <= 0.4f)
                {
                    shieldmax--;
                }
                timer3 = 4;
                randomValue = 1;
            }
        }



        if (shield == 0)
        {
            object1.SetActive(false);
        }
        if (shield > 0)
        {
            if (object1 != null)
            {
                object1.SetActive(true);
            }

        }
        if (shield < 0)
        {
            shield = 0;
        }
        if (shieldmax < 0)
        {
            shieldmax = 0;
        }

        horizontal = 0f;


        if (StaticScript.player1character == 7)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = 1f;
            }
        }
        else if (StaticScript.player2character == 7)
        {

            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1f;
            }

        }
        else if (StaticScript.player3character == 7)
        {
            if (move < 0f)
            {
                horizontal = -1f;
            }

            else if (move > 0f)
            {
                horizontal = 1f;
            }
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

        if (StaticScript.player1character == 7)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }

        else if (StaticScript.player2character == 7)
        {
            if ((Input.GetKeyDown(KeyCode.W)) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }

        else if (StaticScript.player3character == 7)
        {
            if (up > 0  && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }
        if (hi == 1)
        {
            jumpingPower = jumpingPower * 1.75f;
            StartCoroutine(jumpReset());
            hi = 0;
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

    private void OnCollisionEnter2D(Collision2D collision)
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
            timer3 = 0;
            timer2 = 0;
            timer1 = 0;
        }
        if (collision.gameObject == player2.pl2 && player2.invincible == true)
        {
            return;
        }
        if (collision.gameObject == CompareTag("shield"))
        {
            return;
        }
        if (collision.gameObject == CompareTag("shield2"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
            if (shield == 0)
            {
                shieldmax++;
                shield = shieldmax;
                object1.SetActive(true);
            }
            
        }
    }
}
