using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderSuicide : MonoBehaviour
{
    [SerializeField] private GameObject Player4;
    [SerializeField] private GameObject[] enemies;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MurderSuicideFunc();
        }
    }

    void MurderSuicideFunc()
    {
        if (enemies.Length == 0) { return; }

        GameObject closestEnemy = FindClosestEnemy(enemies);

        if (closestEnemy != null) { Destroy(closestEnemy); Destroy(Player4); }
    }

    GameObject FindClosestEnemy(GameObject[] enemies)
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
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
