using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openNextLevelTP : MonoBehaviour
{

    public Rigidbody2D trigger;
    public GameObject platform;
    public GameObject sparkleFX;
    public AudioClip tadaSFX;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((!trigger && !once) )

        {
            AudioSource.PlayClipAtPoint(tadaSFX, transform.position);
            Instantiate(sparkleFX, transform.position, transform.rotation);
            Instantiate(platform, transform.position, transform.rotation);
            once = true;
        }
    }
}
