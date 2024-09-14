using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPortalDown : MonoBehaviour
{
    public Collider2D partner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            partner.enabled = false;
            collision.gameObject.transform.position = new Vector3(
                collision.gameObject.transform.position.x,
                5.3f, collision.gameObject.transform.position.z);
            Invoke("Reenabled", 0.1f);
        }
    }

    private void Reenabled()
    {
        partner.enabled = true;
    }
}
