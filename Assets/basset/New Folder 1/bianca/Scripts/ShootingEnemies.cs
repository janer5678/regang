using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class ShootingEnemies : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private PlayerMovement _player4;

    private float timer = 1f;
    private bool killwhenready;
    float attack1;

    DariusControls1 controls;

    private void Awake()
    {
        controls = new DariusControls1();


        controls.Josh2.Attack1.performed += ctx => attack1 = ctx.ReadValue<float>();
        controls.Josh2.Attack1.canceled += ctx => attack1 = 0f;




    }
    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }

    void Update()
    {

        if (StaticScript.player1character == 5)
        {
            if (Input.GetKey(KeyCode.Slash) && PlayerMovement.leftdir == true && timer < 0)
            {
                Instantiate(_bullet, new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                killwhenready = true;
                timer = 0.3f;
            }

            if (Input.GetKey(KeyCode.Slash) && PlayerMovement.leftdir == false && timer < 0)
            {
                Instantiate(_bullet, new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                killwhenready = true;
                timer = 0.3f;
            }
        }
        else if (StaticScript.player2character == 5)
        {
            if (Input.GetKey(KeyCode.Q) && PlayerMovement.leftdir == true && timer < 0)
            {
                Instantiate(_bullet, new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                killwhenready = true;
                timer = 0.3f;
            }

            if (Input.GetKey(KeyCode.Q) && PlayerMovement.leftdir == false && timer < 0)
            {
                Instantiate(_bullet, new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                killwhenready = true;
                timer = 0.3f;
            }
        }
        else if (StaticScript.player3character == 5)
        {
            if (attack1 > 0 && PlayerMovement.leftdir == true && timer < 0)
            {
                Instantiate(_bullet, new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                killwhenready = true;
                timer = 0.3f;
            }

            if (attack1 > 0 && PlayerMovement.leftdir == false && timer < 0)
            {
                Instantiate(_bullet, new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                killwhenready = true;
                timer = 0.3f;
            }
        }

        timer = timer - Time.deltaTime;
        
    }

}
