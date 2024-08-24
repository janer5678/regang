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
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        CountStart = true;
        Countdown = 0.5f;
    }
}
