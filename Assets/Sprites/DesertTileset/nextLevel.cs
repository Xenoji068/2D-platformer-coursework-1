using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    public GameObject nextlevel;    // Start is called before the first frame update
    public Rigidbody2D character;


    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            character.transform.position = new Vector2(nextlevel.transform.position.x , nextlevel.transform.position.y);
        }
    }
}
