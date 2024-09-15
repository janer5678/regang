using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerMovement.leftdir == true)
        {
            rb.velocity = Vector3.left * 10f;
        } else
        {
            rb.velocity = Vector3.right * 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);

            if (gameObject.name != "Player4")
            {
                Destroy(collision.gameObject);

            }
        }
    }
}
