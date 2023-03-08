using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public static float coinCount;
    [SerializeField] float coinValue;
    public AudioClip collectSFX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")== true)
        {
            AudioSource.PlayClipAtPoint(collectSFX, transform.position);
            coinCount += coinValue;
            Destroy(gameObject);
        }
    }
}
