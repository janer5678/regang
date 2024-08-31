using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfYouHitJosh1HeDie : MonoBehaviour
{
    private GameObject JoshCharacter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Josh1")
        {
            JoshCharacter = GameObject.FindWithTag("Josh1");
            Destroy(JoshCharacter);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "wall")
        {
            print("hello");
            Destroy(gameObject);


        }


    }
}
