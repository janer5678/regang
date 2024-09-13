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

    // Start is called before the first frame update
    

    void Start()
    {
        
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

        if(Input.GetKey(KeyCode.Q))
        {


            if (CountStart == false)
            {
                Shoot();

            }
        }




        if (Input.GetKeyDown(KeyCode.Alpha1) && cooldown < 0)
        {
            BigShoot();
            cooldown = 3f;
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
