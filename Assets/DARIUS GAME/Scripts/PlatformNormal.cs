using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformNormal : MonoBehaviour
{
    public int hP;
    public int damage1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != "player")
        {
            hP = hP - damage1;
        }
    }
}
