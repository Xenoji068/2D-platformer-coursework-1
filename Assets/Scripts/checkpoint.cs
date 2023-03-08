using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Rigidbody2D charRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            characterController.respawnPoint = charRB.position;
            
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
