using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    //move character
    public float maxCharacterSpeed; //max speed character can move at
    public static bool facingRight;
    public float move;
    public float moveRaw;




    //cooldown
    public float cooldownTime;
    public float nextFireTime ;

    //BETTER JUMP
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    

    //jump
    public LayerMask groundLayer;
    public LayerMask oWLayer;
    public Transform groundCheck;
    public float jumpSpeed;

    public bool grounded = false;
    public bool oneWay = false;
    float groundCheckRadius = 0.2f; //checks if character is on the ground


    public AudioClip jumpSFX;


    static Rigidbody2D charRB; //reference to the characters rigidbody2d component
    Animator charAnimator; //refence to the characters animations such as speed.


    //Respawn 

    public static Vector3 respawnPoint;
    public static bool hasRespawned;
    // Start is called before the first frame update


    private void Awake()
    {
        charRB = GetComponent<Rigidbody2D>(); // finds the rigid body component and makes a reference
    }


    void Start()
    {
        //respawn
        respawnPoint = transform.position;
        hasRespawned = false;
        charRB = GetComponent<Rigidbody2D>(); // finds the rigid body component and makes a reference
        charAnimator = GetComponent<Animator>();
        facingRight = true; //initalisies variable so its true on start-up of game
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal"); // move with a or d, gives a value between -1,0 and 1
        moveRaw = Input.GetAxis("Horizontal");
        charAnimator.SetFloat("speed", Mathf.Abs(move)); //make the character go into run animation, finds the speed variable in the animatior scene and sets it to our move variable

        charRB.velocity = new Vector2(move * maxCharacterSpeed, charRB.velocity.y); //move in the x axis by move(above value) * max speed. 
       

        if(move > 0 && !facingRight) //if they are pressing 'd' and facing left
        {
            flip(); //flips character
        }else if(move < 0 && facingRight) //if they are pressing 'a' and facing right
        {
            flip(); //flip character
        }

        //JUMP - check if we are grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //draws circle to check if grounded if the circle intersects the ground layer then its true else its false and we are falling
        oneWay = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, oWLayer);
        charAnimator.SetBool("isGrounded", (oneWay|| grounded));
        //charAnimator.SetBool("isGrounded", oneWay);

        charAnimator.SetFloat("verticalSpeed", charRB.velocity.y);
    }
    private void Update()
    {
        


        //BETTER JUMP 
        if (charRB.velocity.y < 0)
        {
            charRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (charRB.velocity.y > 0 && !Input.GetButton("Jump")) 
        {
            charRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }


        //JUMP
        if ((grounded && Input.GetKeyDown("space"))||(oneWay && Input.GetKeyDown("space")) )
        {

            grounded = false;
            oneWay = false;

            AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
            charAnimator.SetBool("isGrounded", grounded);
            charRB.velocity = new Vector2(charRB.velocity.x, jumpSpeed);
        }
    }

    private void flip() //flips character 
    {
        facingRight = !facingRight;
        /*Vector3 characterScale = transform.localScale; //getting the transform from scale, vector 3 is needed as scale is x,y,z
        characterScale.x *= -1; //flipss the x value to negative
        transform.localScale = characterScale; // the actual input = to negative input*/

        transform.Rotate(0f, 180, 0);
    }


    //respawn
    public static void respawn()
    {
        
        charRB.position = respawnPoint;
        hasRespawned = true;

    }

}
