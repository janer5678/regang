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


        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "player") && collision.gameObject.name != "player_darius")
        {
            if (collision.gameObject.name == "player3" && player3.invincible == true)
            {
                Destroy(gameObject);
            }

            else
            {
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }


    }
}
