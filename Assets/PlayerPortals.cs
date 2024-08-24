using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;


    private void Update()
    {
        portal1 = GameObject.FindGameObjectWithTag("portal1");
        portal2 = GameObject.FindGameObjectWithTag("portal2");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "portal1")
        {
            gameObject.transform.position = new Vector2(portal2.transform.position.x - 1f, portal2.transform.position.y);
        }
        if (collision.gameObject.tag == "portal2")
        {
            gameObject.transform.position = new Vector2(portal1.transform.position.x + 1f, portal1.transform.position.y);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "portal1")
        {
            print("trigger hit");
            gameObject.transform.position = new Vector2(portal2.transform.position.x - 1f, portal2.transform.position.y);
        }
        if (collision.gameObject.tag == "portal2")
        {
            gameObject.transform.position = new Vector2(portal1.transform.position.x + 1f, portal1.transform.position.y);
        }

    }


}
