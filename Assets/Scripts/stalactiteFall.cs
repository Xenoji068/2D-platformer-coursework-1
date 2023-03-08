using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stalactiteFall : MonoBehaviour
{
    public Rigidbody2D stalactite;
     GameObject stalactiteTrigger;
    public float fallSpeed;

    private Vector3 horizontalMovement;
    public AudioClip fallingSFX;
    // Start is called before the first frame update
    void Start()
    {

        stalactiteTrigger = GetComponent<GameObject>();

    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y-8f), new Vector2(0.2f, 8f),-20f);
        try
        {
            if (hit.collider.tag == "Player" )
            {
                AudioSource.PlayClipAtPoint(fallingSFX, transform.position);
                stalactite.velocity = new Vector2(0, -fallSpeed);
                print("hit.collider.name");
            }
        }
        catch
        {

        }
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 12f), new Vector2(0.2f, 8f)) ;
    }
}
