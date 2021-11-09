using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallSlide : MonoBehaviour
{
    //wall slide
    public Transform wallCheck;
    float wallCheckRadius = 0.2f; //checks if character is on the ground
    public LayerMask groundLayer;
    public float slideSpeed = 4f;
    characterController controlMovement;
    Rigidbody2D charRB; //reference to the characters rigidbody2d component


    //Wall Jump
    bool wallJumping;
    public bool touchingLeft;
    public bool touchingRight;

    float touchingLeftOrRight;

    
    static public bool unlocked = false;
    // Start is called before the first frame update


    void Start()
    {
 
        charRB = GetComponent<Rigidbody2D>(); // finds the rigid body component and makes a reference
        controlMovement = GetComponent<characterController>();
    }

    // Update is called once per frame
    void Update()
    {
         
            //onWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer); //draws circle to check if grounded if the circle intersects the ground layer then its true else its false and we are falling

            touchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - .65f, gameObject.transform.position.y), new Vector2(0.2f, 2.5f), 0f, groundLayer);
            touchingRight = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 0.65f, gameObject.transform.position.y), new Vector2(0.2f, 2.5f), 0f, groundLayer);


            //wall slide
            if (touchingLeft)
            {
                WallSlide();

            }
            if (touchingRight)
            {
                WallSlide();

            }

            if (touchingLeft)
            {
                touchingLeftOrRight = 1;
            }else if (touchingRight)
            {
                touchingLeftOrRight = -1;
            }

        if (unlocked)
        {
            //wall jumping
            if (Input.GetKeyDown("space") && (touchingRight || touchingLeft) && !controlMovement.grounded)
            {
                wallJumping = true;
                Invoke("wallJumpToFalse", 0.2f);
            }

            if (wallJumping)
            {
                charRB.velocity = new Vector2( (controlMovement.maxCharacterSpeed * touchingLeftOrRight)  , controlMovement.jumpSpeed);
             }

        }
    }

    //Draw Boxes for touching left and right
     void OnDrawGizmosSelected()
    {
        //left
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 0.65f, gameObject.transform.position.y), new Vector2(0.2f, 2.5f));

        //right
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 0.65f, gameObject.transform.position.y ), new Vector2(0.2f, 2.5f));

    }

    void WallSlide()
    {
        charRB.velocity = new Vector2(charRB.velocity.x, -slideSpeed);
    }

    void wallJumpToFalse()
    {
        wallJumping = false;

    }
}
