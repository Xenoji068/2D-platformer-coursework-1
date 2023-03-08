using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFiring : MonoBehaviour
{
    public int weaponDamage = 10;


    public float projectileSpeed = 20f;
    public AudioClip fireBallSFX;


    public LayerMask shootableLayer;
    public Rigidbody2D projectileRB;
    characterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(fireBallSFX, transform.position);

        if (transform.localRotation.z < 0)
        {
            projectileRB.velocity = transform.right * -projectileSpeed;
        }
        else
        {
            projectileRB.velocity = transform.right * projectileSpeed;

        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {

                    enemyHealth enemy = collision.GetComponent<enemyHealth>();
                    BigSlimeDead bigEnemy = collision.GetComponent<BigSlimeDead>();
                    {
                        if (enemy != null)
                        {
                            enemy.TakeDamage(weaponDamage);

                        }
                        else if(bigEnemy != null)
                        {
                            bigEnemy.TakeDamage(weaponDamage);
                        }
                    }
                    Destroy(gameObject);
        }
       
    }
}
