using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    

    public GameObject projectile;
    public GameObject projectile2;

    public Transform firePoint;
    static public bool unlocked = false;


    //cooldown
    float timeStamp;
    [SerializeField] float coolDownPeriodInSeconds;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            if (collect.coinCount < 6) 
            {

                if (timeStamp <= Time.time)
                {

                    if (Input.GetButtonDown("Fire1"))
                    {

                        fire();
                        timeStamp = Time.time + 1;

                    }
                }
            }

            if(collect.coinCount >= 6)
            {
                if (timeStamp <= Time.time)
                {

                    if (Input.GetButtonDown("Fire1"))
                    {


                        Darkfire();
                        timeStamp = Time.time + 0.5f;

                    }
                }
            }

        }
        


    }

    private void Darkfire()
    {
        Instantiate(projectile2, firePoint.position, firePoint.rotation);
    }

    private void fire()
    {                    

        
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        
    }
}
 
