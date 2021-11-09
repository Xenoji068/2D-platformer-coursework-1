using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnLimit : MonoBehaviour
{
    public float timeAlive;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, timeAlive);
    }
      
}
