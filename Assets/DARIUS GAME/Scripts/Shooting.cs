using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private bool CountStart;
    private float Countdown = 0.5f;
    public GameObject bullet;

    public GameObject b1;  
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
        
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;

    private float cooldown = 0f;
    DariusControls controls;
    float attack1;
    float attack2;

    void Awake()
    {
        controls = new DariusControls();

        controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
        controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;
    }

    // Start is called before the first frame update


    void Start()
    {
        
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

        if (CountStart)
        {
            Countdown = Countdown - 1 * Time.deltaTime;
            print(Countdown);
        }
        if (Countdown <= 0)
        {
            CountStart = false;
        }

        if (StaticScript.player2character == 2)
        {
            if (Input.GetKey(KeyCode.Q))
            {


                if (CountStart == false)
                {
                    Shoot();

                }
            }
        }
        else if (StaticScript.player1character == 2)
        {
            if (Input.GetKey(KeyCode.Slash))
            {


                if (CountStart == false)
                {
                    
                    Shoot();

                }
            }
        }
        else if (StaticScript.player3character == 2)
        {
            if (attack1 > 0)
            {


                if (CountStart == false)
                {

                    Shoot();

                }
            }
        }



        if (StaticScript.player2character == 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && cooldown < 0)
            {
                BigShoot();
                cooldown = 3f;
            }
        }
        else if (StaticScript.player1character == 2)
        {
            if (Input.GetKeyDown(KeyCode.Period) && cooldown < 0)
            {
                BigShoot();
                cooldown = 3f;
            }
        }


        else if (StaticScript.player3character == 2)
        {
            if (attack2 > 0 && cooldown < 0)
            {
                BigShoot();
                cooldown = 3f;
            }
        }


        cooldown = cooldown - 1 * Time.deltaTime;

    }

    

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        CountStart = true;
        Countdown = 0.5f;
    }

    void BigShoot()
    {
        
        Instantiate(b1, new Vector2(transform.position.x - 0.3f, transform.position.y) , transform.rotation);
        Instantiate(b2, new Vector2(transform.position.x + 0.3f, transform.position.y), transform.rotation);
        Instantiate(b3, new Vector2(transform.position.x, transform.position.y + 0.3f), transform.rotation);
        Instantiate(b4, new Vector2(transform.position.x, transform.position.y - 0.3f), transform.rotation);


        Instantiate(b5, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.3f), transform.rotation);
        Instantiate(b6, new Vector2(transform.position.x + 0.3f, transform.position.y + 0.3f), transform.rotation);
        Instantiate(b7, new Vector2(transform.position.x - 0.3f, transform.position.y - 0.3f), transform.rotation);
        Instantiate(b8, new Vector2(transform.position.x + 0.3f, transform.position.y - 0.3f), transform.rotation);
    }

}
