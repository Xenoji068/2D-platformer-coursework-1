using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teeest : MonoBehaviour
{
    Rigidbody2D ee;
    bool spell;
    // Start is called before the first frame update
    void Start()
    {
        ee = GetComponent<Rigidbody2D>();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            projectileFiring newPower = collision.gameObject.GetComponent<projectileFiring>();
            spell = true;
           
            Destroy(gameObject);

        }

    }


}
