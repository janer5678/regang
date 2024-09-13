using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blues : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool bulletFacing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gunscript2.right2 == true)
        {
            rb.velocity = Vector3.right * 8;
        }
        if (gunscript2.right2 != true)
        {
            rb.velocity = Vector3.left * 8;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (player2.bulletDirection == true && bulletFacing == false)
        {
            bulletFacing = true;
            rb.velocity = rb.velocity * -1;
        }
        if (bulletFacing == true && player2.bulletDirection == false)
        {
            bulletFacing = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player3.pl3 && player3.invincible == true)
        {
            return;
        }
        if (collision.gameObject == CompareTag("shield"))
        {
            return;
        }
        if (collision.gameObject == CompareTag("shield2"))
        {
            if (player3.invincible == false)
            {
                player3.shield--;
                return;
            }
            return;
        }
        if (collision.gameObject == player2.pl2 && player2.invincible == true)
        {
            return;
        }
        if (!collision.gameObject.CompareTag("blue") && !collision.gameObject.CompareTag("bigboomerang") && collision.gameObject != player2.pl2 && !collision.gameObject.CompareTag("wall") && !collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            player2.kill = true;
        }
    }

}
