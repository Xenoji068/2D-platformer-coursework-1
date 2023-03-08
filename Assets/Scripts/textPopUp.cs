using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPopUp : MonoBehaviour
{
    public GameObject text;



    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            text.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            text.gameObject.SetActive(false);

        }
    }

}
