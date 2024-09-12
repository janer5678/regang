using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    //[SerializeField] private GameObject boomarang;
    // Start is called before the first frame update
    public Transform playerTransform;
    public GameObject myPrefab;
    public GameObject myPrefab2;
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
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.3f, gameObject.transform.position.y, gameObject.transform.position.z);
                right = !right;
            } else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.3f, gameObject.transform.position.y, gameObject.transform.position.z);
                right = !right;
            }
            player.staticGunFliped = false;
        }
        
        if (player.crouchNow == true)
        {
            player.crouchNow = false;
            if (right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.3f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.3f, gameObject.transform.position.y - 0.4f, gameObject.transform.position.z);

            }
        } 
        if (player.notcrouchNow == true)
        {
            player.notcrouchNow = false;
            if (right)
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x + 0.3f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
            else
            {
                gameObject.transform.position = new Vector3(Player.transform.position.x - 0.3f, gameObject.transform.position.y + 0.4f, gameObject.transform.position.z);

            }
        }


        if (StaticScript.player1character == 1)
        {
            if (Input.GetKey(KeyCode.Slash) && player.timer1 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player.timer1 = 200/5;
                
            }
        }
        else if (StaticScript.player2character == 1)
        {
            if (Input.GetKey(KeyCode.Q) && player.timer1 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player.timer1 = 200 / 5;
                
            }
        }

        if (StaticScript.player1character == 1)
        {
            if (Input.GetKey(KeyCode.Period) && player.timer2 == 0)
            {
                Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -3.5f, gameObject.transform.position.z), Quaternion.identity);
                player.timer2 = 4000 / 5;

            }
        }
        else if (StaticScript.player2character == 1)
        {
            if (Input.GetKey(KeyCode.Alpha1) && player.timer2 == 0)
            {
                Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -3.5f, gameObject.transform.position.z), Quaternion.identity);
                player.timer2 = 4000 / 5;

            }
        }


    }
}
