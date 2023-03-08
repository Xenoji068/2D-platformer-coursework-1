using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giantStalactite : MonoBehaviour
{
    Rigidbody2D GS;
    public GameObject sp;
    // Start is called before the first frame update
    void Start()
    {
        GS = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.hasRespawned)
        {
            GS.velocity = new Vector2(0, 0);
            GS.transform.position = new Vector2(sp.transform.position.x, sp.transform.position.y);
            characterController.hasRespawned = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            print("sss");
            GS.transform.position = new Vector2(sp.transform.position.x,sp.transform.position.y);
            GS.velocity = new Vector2(0,0);

        }
    }
}
