using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSlime : MonoBehaviour

{
    public float shootTime; //how often it can shoot
    float nextShootTime; // next time it can shoot
    public int chanceShoot;
   
    public GameObject projectile;
    Animator shootAnim;
    public Rigidbody2D RS;
    public Transform shootArea1;
    public Transform shootArea2;
    public Transform shootArea3;

    public AudioSource bossMusic;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource bossMusic = gameObject.GetComponent<AudioSource>();
        AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();

        shootAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
        bossMusic.Play();
        backgroundMusic.Stop();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            {
                Instantiate(projectile, shootArea1.position, Quaternion.identity);
                Instantiate(projectile, shootArea2.position, Quaternion.identity);
                Instantiate(projectile, shootArea3.position, Quaternion.identity);

                
                
               shootAnim.SetTrigger("slimeShoot");

                
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossMusic.Stop();
            backgroundMusic.Play();
        }

    }
}
