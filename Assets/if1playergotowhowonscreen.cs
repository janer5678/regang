using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class if1playergotowhowonscreen : MonoBehaviour
{
    int cool;
    void Update()
    {
        cool = (GameObject.FindGameObjectsWithTag("player").Length + GameObject.FindGameObjectsWithTag("Player").Length);
        print(cool);

    }
}
