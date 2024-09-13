using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class forbigbulletleft : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "b1")
        {
            rb.velocity = Vector3.left * speed;

        }
        else if (gameObject.tag == "b2")
        {
            rb.velocity = Vector3.right * speed;

        }
        else if (gameObject.tag == "b3")
        {
            rb.velocity = Vector3.up * speed;
        }
        else if (gameObject.tag == "b4")
        {
            rb.velocity = Vector3.down * speed;
        }
        else if (gameObject.tag == "b5")
        {
            rb.velocity = (Vector3.up + Vector3.left) * speed / 1.41421356237f;
        }


        else if (gameObject.tag == "b6")
        {
            rb.velocity = (Vector3.up + Vector3.right) * speed / 1.41421356237f;
        }


        else if (gameObject.tag == "b7")
        {
            rb.velocity = (Vector3.down + Vector3.left) * speed / 1.41421356237f;
        }
        else if (gameObject.tag == "b8")
        {
            rb.velocity = (Vector3.down + Vector3.right) * speed / 1.41421356237f;
        }






    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player_darius")
        {
            
        }

        else if(collision.gameObject.tag == "player")
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Update()
    {
        
    }
}
