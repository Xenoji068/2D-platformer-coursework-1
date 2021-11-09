using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    
    // Start is called before the first frame update
 

    void activate()
    {
        wallSlide.unlocked = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            activate();
            Destroy(gameObject);
        }
       
    }
}
