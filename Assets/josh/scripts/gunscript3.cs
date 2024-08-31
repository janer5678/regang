using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript3 : MonoBehaviour
{
    //[SerializeField] private GameObject boomarang;
    // Start is called before the first frame update
    public Transform playerTransform;
    public float throwForce = 10f;

    public GameObject Player;
    public static bool right = false;

    void Start()
    {
        
       

    }

    // Update is called once per frame
    void Update()
    {
        

        if (player3.staticGunFliped == true)
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
            player3.staticGunFliped = false;
        }
        
        if (player3.crouchNow == true)
        {
            player3.crouchNow = false;
            if (right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.4f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.4f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
        } 
        if (player3.notcrouchNow == true)
        {
            player3.notcrouchNow = false;
            if (right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.4f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.4f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
        }

        
    }
}
