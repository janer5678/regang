using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleScript : MonoBehaviour
{
    public GameObject Player;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("blue") && !collision.gameObject.CompareTag("wall") && !collision.gameObject.CompareTag("ground") && !collision.gameObject.CompareTag("player2") && !collision.gameObject.CompareTag("bigboomerang"))
        {
            Destroy(collision.gameObject);
            player2.kill = true;
        }
    }
}
