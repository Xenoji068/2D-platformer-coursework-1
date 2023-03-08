using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterHealth : MonoBehaviour
{
    public static float fullHealth = 100;


   public static  float currentHealth = fullHealth;
    public Image damageScreen;
    bool damaged = false;
    Color damagedColour = new Color(255f, 0f, 0f, 0.5f);
    float smoothColour = 5f;
    //lives 
    public static int lives = 2;

    public GameObject deadFX;
   public AudioClip respawnSFX;
    //HUD variables;
    public Slider healthSlider;
   public Slider staminaSlider;

    characterController controlMovement;

    //gameover screen
   public AudioClip gameOverSFX;
   public AudioClip hurtSFX;

    public Text gameOverScreen;
    //WIN GAME SCREEN
    public Text youWonScreen;
    public AudioClip youWinSFX;
    //restart
    public restartGame theGameManager;
    // Start is called before the first frame update
    void Start()
    {
        controlMovement = GetComponent<characterController>();

        //HUD initialiser
        healthSlider.maxValue = fullHealth;
        healthSlider.value = currentHealth;

        staminaSlider.maxValue = 1;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColour;
        }else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;




        if (currentHealth > (fullHealth / 2))
        {
            healthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;

        }

  

        if (currentHealth <= (fullHealth / 2))
        {
            healthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;

        }
        if (currentHealth <= (fullHealth / 4))
        {
            healthSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
        }

        if (Teleport.unlocked == true) 
        { 
            if (Time.time > controlMovement.nextFireTime)
            {
                staminaSlider.value = 1;
            }
            else
            {
                staminaSlider.value = 0;
            }
        }
        

    }
    public void addDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }
      /**/  else {
            AudioSource.PlayClipAtPoint(hurtSFX, transform.position);
            currentHealth -= damage;
            healthSlider.value = currentHealth;
            damaged = true; 
        }
        if ((currentHealth <= 0) && lives ==0)
        { 
            makeDead();
           
           
        }

        //for respawn
        else if ((currentHealth <= 0) && lives >= 1)
        {

            lives -= 1;
            print(lives + "lives remaining");
            currentHealth = fullHealth / 2;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(respawnSFX, transform.position);
            characterController.respawn();
        }
    }
    public void addHealth(float healthValue)
    {
        currentHealth += healthValue;
        
        if (currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }    
        healthSlider.value = currentHealth;       
        
        
    }
    public void makeDead()
    {
        Instantiate(deadFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);
        Destroy(gameObject);
        damageScreen.color = damagedColour;
        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.resartGame();
        print("G-O");
    }

    public void winGame()
    {
        AudioSource.PlayClipAtPoint(youWinSFX, transform.position);
        Destroy(gameObject);
        Animator youWinAnimator = youWonScreen.GetComponent<Animator>();
        youWinAnimator.SetTrigger("gameOver");
        theGameManager.resartGame();
    }
}
