using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegsSystem : MonoBehaviour
{
    public float maxHP, currentHP, damage;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            Invoke("DoDestroy", 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            currentHP = currentHP - damage;
            Destroy(bullet);
        }
    }

    void DoDestroy()
    {
        Destroy(gameObject);
    }
}
