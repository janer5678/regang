using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPortalUp : MonoBehaviour
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
                -4.5f, collision.gameObject.transform.position.z);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 40f, ForceMode2D.Impulse);
            Invoke("Reenabled", 0.1f);
        }
    }

    private void Reenabled()
    {
        partner.enabled = true;
    }
}
