using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigSlimeDead : MonoBehaviour
{
    public int enemyMaxHealth;
    int enemyCurrentHealth;
    public GameObject enemyDeadFX;
    public Slider enemyHealthSlider;

    public GameObject spawnSlime;

    public Transform slimeSpawnL;
    public Transform slimeSpawnR;

    Color orange = new Color(255f, 100f, 0f, 1);

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = enemyMaxHealth;
        enemyHealthSlider.value = enemyMaxHealth;

    }


    public void TakeDamage(int damage)
    {
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
        Instantiate(enemyDeadFX, transform.position, transform.rotation);

        Instantiate(spawnSlime, slimeSpawnL.position, slimeSpawnL.rotation);
        Instantiate(spawnSlime, slimeSpawnR.position, slimeSpawnR.rotation);


        Destroy(gameObject);
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
