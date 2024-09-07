using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupjump : MonoBehaviour
{
    public GameObject orb;
    public GameObject myPrefab;
    public int timer1 = 20 * 60;
    public static bool a = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer1 != 0 && a == true)
        {
            timer1--;
        }
        if (timer1 == 0)
        {
            Instantiate(myPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            timer1 = 20 * 60;
            a = false;
        }
        
    }
}
