using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MurderSuicide : MonoBehaviour
{
    [SerializeField] private GameObject Player4;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Animator _animator;

    float timer = 1f;
    bool killwhenready;

    DariusControls1 controls;
    float move;
    float attack2;

    private void Awake()
    {
       controls = new DariusControls1();

        controls.Josh2.Attack2.performed += ctx => attack2 = ctx.ReadValue<float>();
        controls.Josh2.Attack2.canceled += ctx => attack2 = 0f;




    }

    void OnEnable()
    {
        controls.Josh2.Enable();  // Ensure your action map is enabled
    }

    void OnDisable()
    {
        controls.Josh2.Disable(); // Disable to avoid memory leaks or errors
    }
    private void Start()
    {
        _animator.SetBool("MurderS", false);
    }
    void Update()
    {
        if (StaticScript.player1character == 1)
        {
            enemies[1] = GameObject.Find("player");

        }
        else if (StaticScript.player1character == 2)
        {
            enemies[1] = GameObject.Find("player_darius");
        }
        else if (StaticScript.player1character == 3)
        {
            enemies[1] = GameObject.Find("GH_Cube_Player");
        }
        else if (StaticScript.player1character == 4)
        {
            enemies[1] = GameObject.Find("player2");
        }
        else if (StaticScript.player1character == 6)
        {
            enemies[1] = GameObject.Find("moacat");
        }
        else if (StaticScript.player1character == 7)
        {
            enemies[1] = GameObject.Find("player3");
        }
        else if (StaticScript.player1character == 8)
        {
            enemies[1] = GameObject.Find("big blaster");
        }
        else if (StaticScript.player1character == 9)
        {
            enemies[1] = GameObject.Find("11");
        }
        if (StaticScript.player2character == 1)
        {
            enemies[2] = GameObject.Find("player");

        }
        else if (StaticScript.player2character == 2)
        {
            enemies[2] = GameObject.Find("player_darius");
        }
        else if (StaticScript.player2character == 3)
        {
            enemies[2] = GameObject.Find("GH_Cube_Player");
        }
        else if (StaticScript.player2character == 4)
        {
            enemies[2] = GameObject.Find("player2");
        }
        else if (StaticScript.player2character == 6)
        {
            enemies[2] = GameObject.Find("moacat");
        }
        else if (StaticScript.player2character == 7)
        {
            enemies[2] = GameObject.Find("player3");
        }
        else if (StaticScript.player2character == 8)
        {
            enemies[2] = GameObject.Find("big blaster");
        }
        else if (StaticScript.player2character == 9)
        {
            enemies[2] = GameObject.Find("11");
        }
        if (StaticScript.player3character == 1)
        {
            enemies[3] = GameObject.Find("player");

        }
        else if (StaticScript.player3character == 2)
        {
            enemies[3] = GameObject.Find("player_darius");
        }
        else if (StaticScript.player3character == 3)
        {
            enemies[3] = GameObject.Find("GH_Cube_Player");
        }
        else if (StaticScript.player3character == 4)
        {
            enemies[3] = GameObject.Find("player2");
        }
        else if (StaticScript.player3character == 6)
        {
            enemies[3] = GameObject.Find("moacat");
        }
        else if (StaticScript.player3character == 7)
        {
            enemies[3] = GameObject.Find("player3");
        }
        else if (StaticScript.player3character == 8)
        {
            enemies[3] = GameObject.Find("big blaster");
        }
        else if (StaticScript.player3character == 9)
        {
            enemies[3] = GameObject.Find("11");
        }



        if (StaticScript.player1character == 5)
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                _animator.SetBool("MurderS", true);


                killwhenready = true;

            }
        }
        else if (StaticScript.player2character == 5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _animator.SetBool("MurderS", true);


                killwhenready = true;

            }
        }
        else if (StaticScript.player3character == 5)
        {
            if (attack2 > 0)
            {
                _animator.SetBool("MurderS", true);


                killwhenready = true;

            }
        }


        if (killwhenready == true)
        {
            timer = timer - Time.deltaTime;

            if (timer < 0f)
            {
                MurderSuicideFunc();
            }
        }
    }
    void MurderSuicideFunc()
    {
        if (enemies.Length == 0) { return; }

        GameObject closestEnemy = FindClosestEnemy(enemies);

        if (closestEnemy != null) 
        {
            Destroy(closestEnemy);
            Destroy(Player4);
        }
    }

    GameObject FindClosestEnemy(GameObject[] enemies)
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;
            float distance = Vector3.Distance(Player4.transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
