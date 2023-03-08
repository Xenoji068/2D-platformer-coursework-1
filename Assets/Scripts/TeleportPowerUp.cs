using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip unlockSFX;
    void activate()
    {
        Teleport.unlocked = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activate();
            AudioSource.PlayClipAtPoint(unlockSFX,transform.position);
            Destroy(gameObject);
        }

    }
}
