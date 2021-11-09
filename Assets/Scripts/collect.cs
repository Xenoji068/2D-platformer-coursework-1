using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    [SerializeField] float coinCount;
    [SerializeField] float coinValue;
    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")== true)
        {
            print("was " + coinCount);
            coinCount += coinValue;
            print("now " + coinCount);
            Destroy(gameObject);
        }
    }
}
