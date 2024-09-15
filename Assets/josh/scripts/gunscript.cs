using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    Josh1Controls1 controls;
    float attack1;
    float attack2;

    void Awake()
    {
        controls = new Josh1Controls1();
        controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
        controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;

    }
    void Start()
    {
        
       

    }
    private IEnumerator bombshoot()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3.5f, gameObject.transform.position.z), Quaternion.identity);
    }
    private IEnumerator bombshoot2()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3.5f, gameObject.transform.position.z), Quaternion.identity);
    }


    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
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
                player.timer1 = 0.2f;
                
            }
        }
        else if (StaticScript.player2character == 1)
        {
            if (Input.GetKey(KeyCode.Q) && player.timer1 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player.timer1 = 0.2f;
                
            }
        }
        else if (StaticScript.player3character == 1)
        {
            if (attack1 > 0 && player.timer1 == 0)
            {
                Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                player.timer1 = 0.2f;
                
            } 
        }

        

        if (StaticScript.player1character == 1)
        {
            if (Input.GetKey(KeyCode.Period) && player.timer2 == 0)
            {
                Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -3.5f, gameObject.transform.position.z), Quaternion.identity);
                player.timer2 = 4;
                StartCoroutine(bombshoot());
                StartCoroutine(bombshoot2());

            }
        }
        else if (StaticScript.player2character == 1)
        {
            if (Input.GetKey(KeyCode.Alpha1) && player.timer2 == 0)
            {
                Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -3.5f, gameObject.transform.position.z), Quaternion.identity);
                player.timer2 = 4;
                StartCoroutine(bombshoot());
                StartCoroutine(bombshoot2());
            }
        }
        else if (StaticScript.player3character == 1)
        {
            if (attack2 > 0 && player.timer2 == 0)
            {
                Instantiate(myPrefab2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -3.5f, gameObject.transform.position.z), Quaternion.identity);
                player.timer2 = 4;
                StartCoroutine(bombshoot());
                StartCoroutine(bombshoot2());
            }
        }


    }
}
