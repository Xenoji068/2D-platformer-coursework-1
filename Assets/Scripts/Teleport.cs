using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    //Dash
    public float dashForce;

    public float startDashTime;
    float CurrentDashTime;
    float dashDirection;
    /*public*/
    bool isDashing;

    Rigidbody2D charRB;
    public GameObject TeleportFX;
    characterController characterMove;
    public static bool unlocked =false;
    // Start is called before the first frame update
    void Start()
    {
        charRB = GetComponent<Rigidbody2D>();
        characterMove = GetComponent<characterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            //DASH
            if (Time.time > characterMove.nextFireTime)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && characterMove.move != 0)
                {
                    Instantiate(TeleportFX, transform.position, transform.rotation);

                    //print("umm");
                    isDashing = true;
                    CurrentDashTime = startDashTime;
                    charRB.velocity = Vector2.zero;
                    dashDirection = (int)characterMove.move;
                }
                if (isDashing)
                {
                    Instantiate(TeleportFX, transform.position, transform.rotation);
                    charRB.transform.position = new Vector2(charRB.transform.position.x + dashForce * dashDirection, charRB.transform.position.y); //move in the x axis by move(above value) * max speed. 


                    CurrentDashTime -= Time.time + CurrentDashTime;

                    if (CurrentDashTime <= 0)
                    {
                        isDashing = false;
                        characterMove.nextFireTime = Time.time + characterMove.cooldownTime;
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (unlocked)
        {
            if (collision.CompareTag("Ground"))
                {
                    charRB.transform.position = new Vector2(charRB.transform.position.x + dashForce * -dashDirection , charRB.transform.position.y);
                }
        }
      
    }

   
}
