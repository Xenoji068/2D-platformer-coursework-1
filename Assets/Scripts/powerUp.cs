using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public AudioClip unlockSFX;

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
            AudioSource.PlayClipAtPoint(unlockSFX, transform.position);

            Destroy(gameObject);
        }
       
    }
}
