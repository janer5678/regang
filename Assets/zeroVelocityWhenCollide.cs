using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeroVelocityWhenCollide : MonoBehaviour
{
    Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();

            rb.velocity = Vector2.zero;
        }
    }
}

