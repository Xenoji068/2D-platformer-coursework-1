using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(restartNow && resetTime <= Time.time)
        {
            collect.coinCount = 0;
            Shoot.unlocked = false;
            wallSlide.unlocked = false;
            Teleport.unlocked = false;
            characterHealth.lives = 2;

            characterHealth.currentHealth = characterHealth.fullHealth;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void resartGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
