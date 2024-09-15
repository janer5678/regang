using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    private int bounce_count_ = 0;
    Rigidbody2D rb;
    public UnityEngine.Vector2 direction;
    public float life;
    // Start is called before the first frame update
    void Start()
    {
        life = 0;


        GetComponent<BoxCollider2D>().isTrigger = true;
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;


        //this.gameObject.transform.Translate(direction);
        //if (life > 10|| bounce_count_ > 3) { Destroy(this.gameObject); }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }

        if ((collision.gameObject.tag == "player" || collision.gameObject.tag == "Player" ) && collision.gameObject.name != "big blaster")
        {
            Destroy(collision.gameObject);
        }

    }


}
