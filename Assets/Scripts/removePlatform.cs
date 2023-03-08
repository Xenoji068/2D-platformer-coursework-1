using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removePlatform : MonoBehaviour
{
    public  AudioClip tadaSFX;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "removePlatform")
        {
            AudioSource.PlayClipAtPoint(tadaSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
