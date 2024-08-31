using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    //[SerializeField] private GameObject boomarang;
    // Start is called before the first frame update
    public Transform playerTransform;
    public GameObject myPrefab;
    public float throwForce = 10f;

    public GameObject Player;
    public static bool right = false;

    void Start()
    {
        
       

    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.staticGunFliped == true)
        {
            if (!right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                right = !right;
            } else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.4f, gameObject.transform.position.y, gameObject.transform.position.z);
                right = !right;
            }
            player.staticGunFliped = false;
        }
        
        if (player.crouchNow == true)
        {
            player.crouchNow = false;
            if (right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.4f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.4f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
        } 
        if (player.notcrouchNow == true)
        {
            player.notcrouchNow = false;
            if (right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.4f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.4f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
        }

        if (Input.GetKey(KeyCode.N) && player.timer1 == 0)
        {
            Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            player.timer1 = 200;
            
        }
    }
}
