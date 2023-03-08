using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthValue;
    public AudioClip healSFX;

    public void FixedUpdate()
    {
        
    }












    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(healSFX, transform.position);
            characterHealth healthOfPlayer = collision.gameObject.GetComponent<characterHealth>();
            healthOfPlayer.addHealth(healthValue);
            Destroy(gameObject);

        }
    }
}
