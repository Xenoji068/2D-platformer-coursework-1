using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public int enemyMaxHealth;
    int enemyCurrentHealth;
    public GameObject enemyDeadFX;
    public Slider enemyHealthSlider;

    Color orange = new Color(255f, 100f, 0f, 1);
    public AudioClip enemyDeadSFX;
    public AudioClip enemyHurtSFX;
    public bool drops;
    public int dropsOutOff;
    public GameObject theDrop;
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyMaxHealth;
        enemyHealthSlider.value = enemyMaxHealth;

    }


    public void TakeDamage (int damage)
    {
        AudioSource.PlayClipAtPoint(enemyHurtSFX, transform.position);
        enemyHealthSlider.gameObject.SetActive(true);

        enemyCurrentHealth -= damage;
        enemyHealthSlider.value = enemyCurrentHealth;

        if (enemyCurrentHealth <= 0)
        {
            enemyDead();
        }
    }

    private void enemyDead()
    {

        AudioSource.PlayClipAtPoint(enemyDeadSFX, transform.position);
        Destroy(gameObject);
        Instantiate(enemyDeadFX, transform.position, transform.rotation);

        if (drops) { 
            int rngDrop = UnityEngine.Random.Range(0, dropsOutOff);
            if (rngDrop == 0)
            {
                Instantiate(theDrop, transform.position, transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= (enemyMaxHealth / 4) * 3)
        {
            enemyHealthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
        }
        if (enemyCurrentHealth <= (enemyMaxHealth / 2))
        {
            enemyHealthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = orange;
        }
        if (enemyCurrentHealth <= (enemyMaxHealth / 4))
        {
            enemyHealthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;

        }
    }
}
