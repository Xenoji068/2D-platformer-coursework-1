using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    bool isFire;
    bool isIce;
    bool isLightning;

    public GameObject projectile;
    public Transform firePoint;

    static public bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                fire();
            }
        }
        


    }

    private void fire()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
 
