using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletmove : MonoBehaviour
{
    private bool switch1;
    private float timer;
    public float derection;



    public GameObject mao;

    private void Start()
    {
        mao = GameObject.Find("moacat");

        if (mao.GetComponent<MaoMove>().left == true)
        {
            derection = -1;
        }
        else
        {
            derection = 1;
        }
    }

    void Update()
    {
        timer = timer - Time.deltaTime;








        if (switch1 == true)
        {
            transform.position = new Vector2(transform.position.x + derection * Time.deltaTime* 7, transform.position.y + 1 * Time.deltaTime * 7);

        }
        else
        {
            transform.position = new Vector2(transform.position.x + derection * Time.deltaTime * 7, transform.position.y - 1 * Time.deltaTime * 7);

        }


        if (timer < 0 && switch1 == true)
        {
            timer = 0.15f;
            switch1 = false;
        }
        else if (timer < 0 && switch1 == false)
        {
            timer = 0.15f;
            switch1 = true;
        }




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "moacat" && collision.gameObject.tag != "ground" && collision.gameObject.tag != "mao")
        {

            if (collision.gameObject.tag == "player" || collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
