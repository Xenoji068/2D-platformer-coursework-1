using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class countdownController : MonoBehaviour
{
    //cooldown
    public float cooldownTime = 2;
   float nextFireTime = 0;




   
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFireTime)
        {

        
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                print("Test");

                nextFireTime = Time.time + cooldownTime;

            }
        }
    }
}
