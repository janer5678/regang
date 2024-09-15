using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifihityouyoudielol : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        transform.position = player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "11" && collision.gameObject.tag != "red")
        {
            Destroy(collision.gameObject);
        }


    }
}
