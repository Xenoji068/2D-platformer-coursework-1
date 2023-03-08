using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giantStalactiteTrigger : MonoBehaviour
{
    public Rigidbody2D GS;
    public float fallSpeed;
    public AudioSource earthQuake;
    
      void Start()
    {
        AudioSource earthQuake = gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            
                print("gg");
                GS.velocity = new Vector2(0, -fallSpeed);
            earthQuake.volume = 0.1f;


            earthQuake.Play();
            
        }
       
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            earthQuake.Stop();
        }


            
    }
}
