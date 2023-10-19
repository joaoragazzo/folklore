using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeathBarUpdate : MonoBehaviour
{

    private float health;
    private float originalHealthSize;
    
    void Start()
    {
        originalHealthSize = transform.localScale.x;
        health = transform.localScale.x * (Player.health / 100); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health >= 0)
        {
            transform.localScale = new Vector3(originalHealthSize * (Player.health / 100), 
                transform.localScale.y,
                transform.localScale.z
            );    
        }
    }
}
