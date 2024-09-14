using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s : MonoBehaviour
{
    private Rigidbody2D rb;
    private int i = 1;
    private int j = 50;
    private int k = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component


            rb = GetComponent<Rigidbody2D>();
        // rb.velocity = Vector3.left * 10;
        if (gunscript.right == true)
        {
            rb.velocity = Vector3.right * 8;
        }
        if (gunscript.right != true)
        {
            rb.velocity = Vector3.left * 8;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        j--;

        if (j == 0)
        {
            if (i == 1 && k ==1)
            {
                rb.velocity = rb.velocity * -1;
                i = 0;
            }
            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player3.pl3 && player3.invincible == true)
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("shield"))
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("shield2"))
        {
            if (player3.invincible == false)
            {
                player3.shield--;
                Destroy(gameObject);
                return;
            }
            return;
        }
        if (collision.gameObject == player2.pl2 && player2.invincible == true)
        {
            return;
        }


        if (i == 0 && collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("ground"))
        {
            rb.velocity = rb.velocity * -1;
            i = 0;
            k = 0;
        }
        if (!collision.gameObject.CompareTag("wall") && !collision.gameObject.CompareTag("ground") && collision.gameObject != player.pl && !collision.gameObject.CompareTag("boomerang"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
