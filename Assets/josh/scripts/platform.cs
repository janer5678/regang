using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed = 5.0f;
    private int timer1 = 900;

    void Update()
    {
        if (timer1 != 0)
        {
            timer1--;
        }
        if (timer1 == 0)
        {
            speed = -speed;
            timer1 = 1000;

        }
        // Move the object to the right continuously
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

}
