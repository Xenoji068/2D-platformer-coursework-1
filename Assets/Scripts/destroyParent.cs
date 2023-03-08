using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (  !gameObject.GetComponentInChildren<CircleCollider2D>() )
        {
            makeDead();
        }
    }
    public void makeDead()
    {

        Destroy(gameObject);
    }
    
}
