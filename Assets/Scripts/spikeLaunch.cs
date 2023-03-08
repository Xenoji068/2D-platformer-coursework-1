using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeLaunch : MonoBehaviour
{
    public float spikeYSpeedHigh;
    public float spikeYSpeedLow;
    public float spikeXSpeed;
    public float spikeTorque;
    Rigidbody2D spike;
    // Start is called before the first frame update
    void Start()
    {
        spike = GetComponent<Rigidbody2D>();
        spike.AddForce(new Vector2(Random.Range(-spikeXSpeed, -spikeXSpeed+5), Random.Range(spikeYSpeedLow, spikeYSpeedHigh)), ForceMode2D.Impulse);
        spike.AddTorque((Random.Range(-spikeTorque, spikeTorque)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
