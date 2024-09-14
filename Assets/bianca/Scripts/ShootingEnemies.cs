using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemies : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private PlayerMovement _player4;

    private float timer = 1f;
    private bool killwhenready;

    void Update()
    {
        if (Input.GetKey(KeyCode.Period) && PlayerMovement.leftdir == true && timer<0)
        {
            Instantiate(_bullet, new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            killwhenready = true;
            timer = 0.3f;
        }

        if (Input.GetKey(KeyCode.Period) && PlayerMovement.leftdir == false && timer<0)
        {
            Instantiate(_bullet, new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            killwhenready = true;
            timer = 0.3f;
        }
        timer = timer - Time.deltaTime;
        
    }

}
