using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterHealth : MonoBehaviour
{
    public float fullHealth;

    float currentHealth;


    //public GameObject deadFX; 

    //HUD variables;
    public Slider healthSlider;
    public Slider staminaSlider;

    characterController controlMovement;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<characterController>();

        //HUD initialiser
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        staminaSlider.maxValue = 1;
       

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > controlMovement.nextFireTime)
        {
            staminaSlider.value = 1;
        }
        else
        {
            staminaSlider.value = 0;
        }

        if (currentHealth <= (fullHealth / 2))
        {
            healthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;

        }
        if (currentHealth <= (fullHealth / 4))
        {
            healthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
        }
    }
    public void addDamage(float damage)
    {
        if(damage<= 0)
        {
            return;
        }
        currentHealth -= damage;
        healthSlider.value = currentHealth;


        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    private void makeDead()
    {
        //Instantiate(deadFX, m.position, transform.rotation)
        Destroy(gameObject);
    }
}
