using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gunscript2 : MonoBehaviour
{





    //[SerializeField] private GameObject boomarang;
    // Start is called before the first frame update
    public Transform playerTransform;
    public GameObject myPrefab;
    public GameObject myPrefab2;
    public GameObject myPrefab3;
    public GameObject myPrefab4;
    public float throwForce = 10f;

    public GameObject Player;
    public static bool right2 = false;




    void Awake()
    {






    }

    void Start()
    {
        
       

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (player2.staticGunFliped2 == true)
        {
            if (!right2)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.7f, gameObject.transform.position.y, gameObject.transform.position.z);
                right2 = !right2;
            } else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.7f, gameObject.transform.position.y, gameObject.transform.position.z);
                right2 = !right2;
            }
            player2.staticGunFliped2 = false;
        }
        
        if (player2.crouchNow2 == true)
        {
            player2.crouchNow2 = false;
            if (right2)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.7f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.7f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
        } 
        if (player2.notcrouchNow2 == true)
        {
            player2.notcrouchNow2 = false;
            if (right2)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.7f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.7f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
        }


        if (StaticScript.player2character == 4)
        {
            if (Input.GetKey(KeyCode.Q) && player2.timer2 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player2.timer2 = 120;
            }
        }
        else if (StaticScript.player1character == 4)
        {
            if (Input.GetKey(KeyCode.Slash) && player2.timer2 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player2.timer2 = 120;
            }
        }
        else if (StaticScript.player3character == 4)
        {
            if (player2.attack1 > 0f && player2.timer2 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player2.timer2 = 120;
            }
        }


        if (player2.bigboomerang == true)
        {
            player2.bigboomerang = false;   
            Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);

        }
        if (player2.blue == true)
        {
            player2.blue = false;
            Instantiate(myPrefab3, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.8f, gameObject.transform.position.z), Quaternion.identity);

        }
        if (player2.blocking2 == true)
        {
            player2.blocking2 = false;
            Instantiate(myPrefab4, new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y  , gameObject.transform.position.z), Quaternion.identity);

        }
    }
}
