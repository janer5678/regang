using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class BossLogic : MonoBehaviour
{

    public Transform player;
    public bool timeup, time, stop;
    public Animator anime;
    public GameObject bossBody, player1;
    public Collider2D playerBody;
    bool isAttacking;
    public float movementSpeed;
    public float attackDistance;
    public float attackCooldown;
    public Collider2D bossMainBody, bossBigLeft, bossBigRight, bossSmallLeft, bossSmallRight;
    // Start is called before the first frame update
    void Start()
    {
        timeup = time = stop = false;
        anime = bossBody.GetComponent<Animator>();
        transform.position = bossBody.transform.position = new Vector3(0f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponent<Move>().dead)
        {
            stop = true;
        }

        if(stop == false)
        {
            if (isAttacking == false)
            {
                MoveToPlayer();
            }
        }
        

        //Invoke("CoolDown", 5.0f);
        //if (timeup & time)
        //{
        //    //transform.position = new Vector2(player.transform.position.x, transform.position.y);

        //    anime.SetBool("Attack", true);
        //    timeup = false;
        //}
        //else if(time & timeup == false)
        //{
        //    time = false;
        //}
    }

    private void CoolDown()
    {
        timeup = time = true;
        isAttacking = false;
    }


    void MoveToPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
        }
        else if (transform.position.x > player.position.x)
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
        }

        float currentDistance = Vector2.Distance(transform.position, player.position);
        if(currentDistance < attackDistance)
        {
            anime.SetTrigger("Attacking");
            isAttacking = true;
            Invoke("CoolDown", attackCooldown);
        }
    }

}
