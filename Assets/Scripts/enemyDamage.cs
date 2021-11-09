using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    public float damage;
    public float damageRate;
    public float knockBackMaginitude;

    float nextDamage;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && nextDamage<Time.time)
        {
            characterHealth thePlayerHealth = collision.gameObject.GetComponent<characterHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            knockBack(collision.transform);
        }
    }

    private void knockBack(Transform pushedObject)
    {
        Vector2 knockBack = new Vector2(pushedObject.position.x - transform.position.x, (pushedObject.position.y - transform.position.y)).normalized;
        knockBack *= knockBackMaginitude;
        Rigidbody2D knockBackRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        knockBackRB.velocity = Vector2.zero;
        knockBackRB.AddForce(knockBack, ForceMode2D.Impulse);

    }
}
