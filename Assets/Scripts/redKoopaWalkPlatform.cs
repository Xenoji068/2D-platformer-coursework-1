using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redKoopaWalkPlatform : MonoBehaviour
{
    public float enemySpeed;
    float detectionDistance = 0.0001f;

    bool movingRight = true;

    public Transform ground;
    public Transform wall;

    Rigidbody2D enemyMove;
    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //enemyMove.velocity = new Vector2(enemySpeed, enemyMove.velocity.y);

        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(ground.position, Vector2.down, detectionDistance);
        RaycastHit2D wallInfo = Physics2D.Raycast(wall.position, Vector2.right, detectionDistance);
        try
        {


            if (groundInfo.collider == false && wallInfo.collider == false || (groundInfo.collider.tag == "Trigger" || wallInfo.collider.tag == "Trigger"))
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0f, -180, 0);

                    movingRight = false;

                }
                else
                {

                    transform.eulerAngles = new Vector3(0f, 0, 0);


                    movingRight = true;
                }
            }
            if (groundInfo.collider == true && wallInfo.collider == true /*&& groundInfo.collider.tag == "Trigger" || wallInfo.collider.tag == "Trigger"*/)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0f, -180, 0);

                    movingRight = false;

                }
                else
                {

                    transform.eulerAngles = new Vector3(0f, 0, 0);


                    movingRight = true;
                }
            }
        }
        catch
        {

        }
        
    }

 
}

