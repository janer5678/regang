using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBomb : MonoBehaviour
{
    public int hP;
    public int damage1;
    public int a = 1;
    [SerializeField] private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator explode()
    {
        for (int i = 0; i < 10; i++)
        {

            gameObject.transform.localScale += new Vector3(0.0015f, 0.0015f, 0.0015f);
            boxCollider.size = new Vector2(boxCollider.size.x + 0.00002f, boxCollider.size.y + 0.00002f);


            //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 5f, gameObject.transform.localScale.y + 5f, 0f);

            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(hP <= 0)
        {
            StartCoroutine(explode());

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {




            if (hP > 0)
        {
            if (collision.collider.tag != "player")
            {
                hP = hP - damage1;
            }
        }


        if(hP <= 0)
        {
            if (collision.gameObject.tag == "ground" ||
                collision.gameObject.tag == "player" ||
                collision.gameObject.tag == "bullet")
            {
                Debug.Log("aaa");
                Destroy(collision.gameObject);
            }
        }

    }
}
