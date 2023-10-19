using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!DayNightCycle.isDay)
        {
            foreach (Renderer rend in transform.GetComponentsInChildren<Renderer>())
            {
                rend.enabled = false;
            }    
        }
        else
        {
            foreach (Renderer rend in transform.GetComponentsInChildren<Renderer>())
            {
                rend.enabled = false;
            }    
        }
        

    }
}
