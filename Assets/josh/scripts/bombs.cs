using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombs : MonoBehaviour
{

    private int hi = 0;
    private Rigidbody2D rb;
    private bool bulletFacing = false;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Transform bomb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        if (gunscript.right == true)
        {
            rb.velocity = Vector3.right * 6;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 3.5f);
        }
        if (gunscript.right != true)
        {
            rb.velocity = Vector3.left * 6;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 3.5f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private IEnumerator explode()
    {
        for (int i = 0; i < 10; i++)
        {

            bomb.localScale += new Vector3(0.003f, 0.003f, 0.003f);
            boxCollider.size = new Vector2(boxCollider.size.x + 0.003f, boxCollider.size.y + 0.003f);
            rb.velocity = new Vector2(0f, 0f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;


            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 5f, gameObject.transform.localScale.y +5f, 0f);
            bomb.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 0.8f, gameObject.transform.position.z);

            yield return new WaitForSeconds(0.015f);  
        }
        Destroy(gameObject);
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


        if (collision.gameObject.CompareTag("bomb"))
        {
            return;
        }
        if (collision.gameObject == player.pl)
        {
            return;
        }
        if (hi == 0)
        {
            StartCoroutine(explode());
            hi = 1;
        }
        if (!collision.gameObject.CompareTag("ground") && !collision.gameObject.CompareTag("wall") &&collision.gameObject != player.pl)
        {
            Destroy(collision.gameObject);
        }


    }
    
}
