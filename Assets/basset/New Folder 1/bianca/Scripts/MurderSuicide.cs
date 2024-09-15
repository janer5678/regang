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
