using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperDroneController : MonoBehaviour
{
    public static bool droneAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(droneAlive);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(droneAlive);
    }
}
