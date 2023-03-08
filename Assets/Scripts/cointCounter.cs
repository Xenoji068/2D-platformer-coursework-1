using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cointCounter : MonoBehaviour
{
    Text coinText;
    public static int cointAmount;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = collect.coinCount.ToString();
    }
}