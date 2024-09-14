using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MurderSuicide : MonoBehaviour
{
    [SerializeField] private GameObject Player4;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Animator _animator;

    float timer = 1f;
    bool killwhenready;

    private void Start()
    {
        _animator.SetBool("MurderS", false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            _animator.SetBool("MurderS", true);


            killwhenready = true;

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
