using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAggro : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] Transform player;
    [SerializeField] float aggroRange;

    Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { try
        {
        if (player == null)
        {
            DontChasePlayer();
        }
        //distamce to player
       
            float distToPlayer = Vector2.Distance(transform.position, player.position);
       
        //print("disToPlayer:" + distToPlayer);

        if(distToPlayer < aggroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop Chasing Player
            DontChasePlayer();
        }

        }
        catch
        {

        }
    }

    private void DontChasePlayer()
    {
       enemyRB.velocity = new Vector2(0,0 );
    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {//if we are on the left, move right

            enemyRB.velocity = new Vector2(enemySpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {//if we are on the right,move left

            enemyRB.velocity = new Vector2(-enemySpeed, 0);
            transform.localScale = new Vector2(-1, 1);

        }
    }
}
