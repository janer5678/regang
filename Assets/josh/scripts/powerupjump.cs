using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupjump : MonoBehaviour
{
    public GameObject orb;
    public GameObject myPrefab;
    public float timer1 = 0;
    public static bool a = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer1 > -1 && a == true)
        {
            timer1 = timer1 - Time.deltaTime;
        }
        if (timer1 < 0)
        {
            Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            timer1 = 10;
            a = false;
        }

    }
}
